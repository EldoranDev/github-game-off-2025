using Godot;
using HyperActive.Entities.Modification;
using System;
using System.Diagnostics;

namespace HyperActive.Entities
{

	[Tool]
	[GlobalClass]
	public partial class Entity : CharacterBody3D
	{
		[Export]
		public Stats Stats { get; set; }

		ModificationManager modificationManager;

		public override void _Ready()
		{
			foreach (var node in GetChildren())
			{
				if (node is ModificationManager)
				{
					modificationManager = node as ModificationManager;
					break;
				}
			}

			modificationManager.ModificationsUpdated += UpdateStats;
		}

		public void UpdateStats(ModificationResult result)
		{
			Stats.Modifications = result;
			Stats.Recalculate();
        }

	}
}