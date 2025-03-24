using UnityEngine;

namespace Architecture.AbilitySystem
{
    public class AbilityModel
    {
        //public readonly ObserableList<Ability> abilities = new();
    }

    public class Ability
    {
        public readonly AbilityData data;
        public Ability(AbilityData data)
        {
            this.data = data;
        }
    }
}
