using Godot;
using HyperActive.Utilities;
using System;

public partial class MainMenu : Node
{
	[Export(PropertyHint.File, "*.tscn")]
	public string StartScene { get; set; }
	
	[Export(PropertyHint.File, "*.tscn")]
	public string OptionsScene { get; set; }

	public void on_start_pressed()
	{
		SceneManager.Instance.GotoScene(StartScene);
	}
	
	public void on_options_pressed()
    {
		SceneManager.Instance.GotoScene(OptionsScene);
    }

	public void on_exit_pressed()
	{
		GetTree().Quit();
	}
}
