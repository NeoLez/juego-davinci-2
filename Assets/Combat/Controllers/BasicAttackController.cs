using UnityEngine;

namespace Combat.Controllers
{
	public class BasicAttackController : FighterController
	{
		private Fighter controlledFighter;
		private PlayerAction currentAction;
		private Fighter currentTarget;
		
		public BasicAttackController(Fighter controlledFighter) {
			this.controlledFighter = controlledFighter;
		}
		
		public (PlayerAction, Fighter) GetCurrentAction() {
			return (currentAction, currentTarget);
		}

		public void ChooseAction(CombatManager combatManager) {
			currentAction = new PlayerActionAttack();
			currentTarget = combatManager.fighterPlayer;

			
			combatManager.Continuar();
		}
	}
}