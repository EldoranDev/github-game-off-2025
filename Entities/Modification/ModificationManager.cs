using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HyperActive.Entities.Modification
{
	[Icon("uid://jryp0ldetygg")]
	[Tool]
	[GlobalClass]
	public partial class ModificationManager : Node
	{
		[Signal]
		public delegate void ModificationsUpdatedEventHandler(ModificationResult modificationResult);

		private List<AbstractModification> modifications = [];

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			CallDeferred(MethodName.Refresh);
		}

		public void Refresh()
		{
			modifications.Clear();

			foreach (AbstractModification item in GetChildren())
			{
				modifications.Add(item);
			}

			EmitSignalModificationsUpdated(CalculateModifications());
		}

		private ModificationResult CalculateModifications()
		{
			ModificationResult res = new();

			foreach (var mod in modifications)
			{
				mod.Apply(res);
			}

			return res;
        }
	}
}
