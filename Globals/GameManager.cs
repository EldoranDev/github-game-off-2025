using Godot;
using System;

namespace HyperActive.Utilities
{
	public partial class GameManager : Node
	{
		public static GameManager Instance { get; private set; }

		private bool _mphActive = false;

		[Signal]
		public delegate void MPHStatusChangedEventHandler(bool status);

		public bool MPHActive
        {
			get { return _mphActive; }
			set
            {
				if (value == _mphActive)
				{
					return;
				}

				_mphActive = value;
				EmitSignalMPHStatusChanged(_mphActive);
            }
        }

		public override void _Ready()
		{
			Instance = this;

			SetProcess(false);
			SetPhysicsProcess(false);
		}

	}
}
