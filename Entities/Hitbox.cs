using System.Diagnostics;
using Godot;

namespace HyperActive.Entities
{
	[GlobalClass]
	public partial class Hitbox : Area3D
	{
		public Stats AttackerStats;

		public override void _Ready()
		{
			Monitorable = false;
			AreaEntered += OnAreaEntered;

/*
			switch (AttackerStats.Faction)
			{
				case Faction.Player:
					SetCollisionMaskValue(1, true);
					break;
				case Faction.Enemy:
					SetCollisionMaskValue(2, true);
					break;
			}
*/
		}
		
		protected void OnAreaEntered(Area3D area)
        {
			if (area is not Hurtbox)
			{
				Debug.WriteLine("Invalid Hurtbox interaction");
				return;
			}

			// TODO: Damage type currently fixed to Melee Attack only 
			(area as Hurtbox).Attack(AttackerStats);
        }

    }
}
