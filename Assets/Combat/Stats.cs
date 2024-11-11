using System;

namespace Combat
{
	[Serializable]
	public class Stats
	{
		public int Health;
		public int Defense;
		public int AttackDamage;

		public Stats(int health, int defense, int attackDamage) {
			this.Health = health;
			this.Defense = defense;
			this.AttackDamage = attackDamage;
		}

        public Stats Clone()
        {
            return new Stats(Health, Defense, AttackDamage);
        }

        public override string ToString() {
			return "{"+$"Health: {Health} Defense: {Defense} AttackDamage: {AttackDamage}"+"}";
		}

		
	}
}