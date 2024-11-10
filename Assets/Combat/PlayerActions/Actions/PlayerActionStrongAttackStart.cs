using Combat.Controllers;
using UnityEngine;

namespace Combat
{
	public class PlayerActionStrongAttackStart : PlayerAction
	{
		public override bool MeetsRequirements(CombatManager combatManager, Fighter target, Fighter actor) {
			return true;
		}

		public override void Run(CombatManager combatManager, Fighter target, Fighter actor) {
			actor.SetController(new ChargingAttackController(actor, PlayerActions.STRONG_ATTACK, 2, actor.GetController()));
			Debug.Log($"<color=#9effbe>{actor.name} starts charging a strong attack</color>");
		}
	}
}