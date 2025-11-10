using Godot;
using HyperActive.Utilities;
using System;

public partial class Options : Node
{
	[Export(PropertyHint.File, "*.tscn")]
	public string MenuScene { get; set; }

	public void On_back_pressed()
    {
		SceneManager.Instance.GotoScene(MenuScene);
    }
}
