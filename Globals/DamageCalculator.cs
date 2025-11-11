
using HyperActive.Entities;

namespace HyperActive.Utilities
{
    public class DamageCalculator
    {
        public static int CalculateDamate(Stats attacker, Stats defender)
        {
            // TODO: Actually perform calculation
            return attacker.MeleeAttack - defender.Defense;
        }
    }
}