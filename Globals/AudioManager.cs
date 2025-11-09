using Godot;
using HyperActive.Utilities;
using System;
using System.Diagnostics;

[Tool]
public partial class AudioManager : Node
{
	public static AudioManager Instance { get; private set; }

	[Export]
	public AudioStream[] BackgroundTracks = [];

	private AudioStreamPlayer _backgroundPlayer;

	private int _busIndex = -1;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;

		SetProcess(false);
		SetPhysicsProcess(false);

		_busIndex = AudioServer.GetBusIndex("Game");
		_backgroundPlayer = (AudioStreamPlayer) GetChild(0);

		GameManager.Instance.MPHStatusChanged += HandleMPHchange;

		HandleMPHchange(GameManager.Instance.MPHActive);
	}

    public override void _ExitTree()
    {
		base._ExitTree();

		GameManager.Instance.MPHStatusChanged -= HandleMPHchange;
    }

	protected void HandleMPHchange(bool status)
	{
		AudioServer.SetBusBypassEffects(_busIndex, !status);
    }
}
