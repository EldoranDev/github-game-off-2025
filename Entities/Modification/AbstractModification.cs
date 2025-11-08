using Godot;
using System;
using System.Diagnostics;

namespace HyperActive.Entities.Modification
{

	[Tool]
	[GlobalClass]
	public abstract partial class AbstractModification : Node
	{
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

		public override string[] _GetConfigurationWarnings()
		{
			if (GetParent().GetType() != typeof(ModificationManager))
			{
				return [
					"Modification must be placed as child of ModificaitonManager"
				];
			}

			return base._GetConfigurationWarnings();
		}

		public abstract void Apply(ModificationResult result);

	}
}
