using UnityEngine;

namespace Combat
{
	public class PlayerActionStrongAttack : PlayerAction
	{
		public override bool MeetsRequirements(CombatManager combatManager, Fighter target, Fighter actor) {
			return true;
		}

		public override void Run(CombatManager combatManager, Fighter target, Fighter actor) {
			target.stats.Health -= actor.stats.AttackDamage * 10;
			Debug.Log($"<color=#9effbe>{actor.name} casts a strong attack to {target.name} for {actor.stats.AttackDamage * 10} damage</color>");
		}
	}
}