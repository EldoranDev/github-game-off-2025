using Godot;
using HyperActive.Utilities;


public partial class FollowCamera : Node3D
{
	[Export]
	public Node3D Target { get; set; }
	[Export]
	public Vector3 Offset { get; set; } = new Vector3(0, 7, -5);

	[ExportGroup("Environment Configuration")]
	[Export]
	public Environment DefaultEnvironment { get; set; }
	[Export]
	public Environment MPHEnvironment { get; set; }

	Camera3D camera;

	public override void _Ready()
	{
		camera = GetViewport().GetCamera3D();
		camera.Environment = DefaultEnvironment;

		// Hook camera to changes to MPH status.
		GameManager.Instance.MPHStatusChanged += HandleMPHchange;

		// Trigger Change for the case that camera joins scene after status was already true for some reason
		HandleMPHchange(GameManager.Instance.MPHActive);
	}

    public override void _ExitTree()
    {
		base._ExitTree();

		GameManager.Instance.MPHStatusChanged -= HandleMPHchange;
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// TODO: Make a bit nicer than static?
		Position = Target.Position + Offset;
	}

	protected void HandleMPHchange(bool status)
    {
		camera.Environment = status ? MPHEnvironment : DefaultEnvironment;
    }
}
