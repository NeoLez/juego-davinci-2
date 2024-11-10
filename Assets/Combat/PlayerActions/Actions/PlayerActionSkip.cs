using UnityEngine;

namespace Combat
{
	public class PlayerActionSkip : PlayerAction
	{
		public override bool MeetsRequirements(CombatManager combatManager, Fighter target, Fighter actor) {
			return true;
		}

		public override void Run(CombatManager combatManager, Fighter target, Fighter actor) {
			Debug.Log($"<color=#9effbe>{actor.name} skips their turn</color>");
		}
	}
}