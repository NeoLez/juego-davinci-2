using UnityEngine;

namespace Combat
{
	public class PlayerActionAttack : PlayerAction
	{
		public override bool MeetsRequirements(CombatManager combatManager, Fighter target, Fighter actor) {
			return true;
		}

		public override void Run(CombatManager combatManager, Fighter target, Fighter actor) {
			target.stats.Health -= actor.stats.AttackDamage;
			Debug.Log($"<color=#9effbe>Fighter {actor.characterData.name} attacks {target.characterData.name} for {actor.stats.AttackDamage} damage</color>");
		}
	}
}