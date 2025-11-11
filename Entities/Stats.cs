using Godot;
using HyperActive.Entities.Modification;

namespace HyperActive.Entities
{
	public enum Faction
	{
		Player,
		Enemy,
		NPC,
	}

	[GlobalClass]
	[Tool]
	public partial class Stats : Resource
	{
		[Export]
		public int BaseHealth { get; set; }

		[Export]
		public int BaseDefense { get; set; }

		[Export]
		public int BaseRangedAttack { get; set; }

		[Export]
		public int BaseMeleeAttack { get; set; }

		[Export]
		public int BaseSpeed { get; set; }

		[Export]
		public Faction Faction { get; set; }

		[Signal]
		public delegate void HealthChangedEventHandler(int health);

		[Signal]
		public delegate void HealthDepletedEventHandler();

		public ModificationResult Modifications { get; set; } = new ModificationResult();

		private int _health;

		public int Health
		{
			get
			{
				return _health;
			}
			set
			{
				_health = value;

				EmitSignalHealthChanged(value);

				if (value <= 0)
				{
					EmitSignalHealthDepleted();
				}
			}
		}

		public int MaxHealth { get; private set; }
		public int Defense { get; private set; }
		public int MeleeAttack { get; private set; }
		public int RangedAttack { get; private set; }
		public int Speed { get; private set; }

		public Stats()
		{
			CallDeferred(MethodName.Recalculate);
		}

		public void Recalculate()
		{
			Health = Mathf.CeilToInt((BaseHealth + Modifications.FlatHealth) * Modifications.HealthMultiplier);
			Speed = Mathf.CeilToInt((BaseSpeed + Modifications.FlatSpeed) * Modifications.SpeedMultiplier);

			Defense = BaseDefense;
			RangedAttack = BaseRangedAttack;
			MeleeAttack = BaseMeleeAttack;
		}
	}
}