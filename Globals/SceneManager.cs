using Godot;
using System;


namespace HyperActive.Utilities
{
	public partial class SceneManager : Node
	{
		public static SceneManager Instance { get; private set; }

		public Node CurrentScene { get; set; }

		public override void _Ready()
		{
			Instance = this;

			CurrentScene = GetTree().Root.GetChild(-1);

			SetProcess(false);
			SetPhysicsProcess(false);
		}

		public void GotoScene(string path)
		{
			CallDeferred(MethodName.DeferredGotoScene);

		}
		
		public void DeferredGotoScene(string path)
        {
			CurrentScene.Free();

			var nextScene = GD.Load<PackedScene>(path);

			CurrentScene = nextScene.Instantiate();

			GetTree().Root.AddChild(CurrentScene);
			GetTree().CurrentScene = CurrentScene;
        }
	}
}
