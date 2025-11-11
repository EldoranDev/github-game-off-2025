using Godot;
using System;
using HyperActive.Entities.Modification;
using HyperActive.Utilities;

namespace HyperActive.Entities.Player.Modifications
{

	[Icon("uid://b6c24er41fgpe")]
	[Tool]
	[GlobalClass]
	public partial class MPH : AbstractModification
	{
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

        public override void Apply(ModificationResult result)
        {
			result.FlatHealth += 10;
			GameManager.Instance.MPHActive = true;
        }
    }
}
