using Godot;

namespace HyperActive.Entities.Modification
{
    public partial class ModificationResult : GodotObject
    {
        public int FlatHealth { get; set; }
        public float HealthMultiplier { get; set; } = 1.0f;

        public int FlatSpeed { get; set; }
        public float SpeedMultiplier { get; set; } = 1.0f;
    }
}
