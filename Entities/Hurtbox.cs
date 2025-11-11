using System;
using Godot;
using HyperActive.Utilities;

namespace HyperActive.Entities
{
	[GlobalClass]
	public partial class Hurtbox : Area3D
	{
		public Stats OwnerStats { get; private set; }

		public override void _Ready()
		{
			OwnerStats = (Owner as Entity).Stats;

			SetCollisionMaskValue(1, false);
			SetCollisionLayerValue(1, false);

/*
			switch (OwnerStats.Faction)
			{
				case Faction.Player:
					SetCollisionLayerValue(1, true);
					break;
				case Faction.Enemy:
					SetCollisionLayerValue(2, true);
					break;
			}
*/
		}


		public void Attack(Stats attacker)
		{
			OwnerStats.Health -= DamageCalculator.CalculateDamate(attacker, OwnerStats);
		}
	}
}