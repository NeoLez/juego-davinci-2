namespace Combat.Controllers
{
	public class PlayerController : FighterController
	{
		private Fighter controlledFighter;
		private PlayerAction currentAction;
		private Fighter currentTarget;

		public PlayerController(Fighter controlledFighter) {
			this.controlledFighter = controlledFighter;
		}
		
		public (PlayerAction, Fighter) GetCurrentAction() {
			return (currentAction, currentTarget);
		}

		public void ChooseAction(CombatManager combatManager) {
			currentAction = new PlayerActionStrongAttackStart();
			currentTarget = combatManager.fighterEnemy;
			
			combatManager.Continuar();
		}
	}
}