using Godot;
using System;

namespace HyperActive.Utilities
{
	public partial class GameManager : Node
	{
		public static GameManager Instance { get; private set; }

		public override void _Ready()
        {
			Instance = this;
        }
	}
}
