using Godot;

namespace HyperActive.Common.Health
{
	[GlobalClass]
	public partial class Health : Node
	{
		[Signal]
		public delegate void HealthChangedEventHandler();
		
		[Signal]
		public delegate void ZeroHealthEventHandler();

		[Export]
		public int MaxLife { get; set; }

		private int currentHealth;

		public override void _Ready()
		{
			currentHealth = MaxLife;
		}

		public void ApplyDamage(int dmg)
        {
			currentHealth -= dmg;

			EmitSignal(SignalName.HealthChanged);

			if (currentHealth <= 0)
			{
				EmitSignal(SignalName.ZeroHealth);	
			}
        }

	}

}