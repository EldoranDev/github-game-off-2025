using Godot;
using System;

public partial class Camera : Node3D
{
	[Export]
	public Node3D Target { get; set; }
	[Export]
	public Vector3 Offset { get; set; } = new Vector3(0, 7, -5);


	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = Target.Position + Offset;
	}
}
