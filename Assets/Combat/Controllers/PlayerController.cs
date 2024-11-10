namespace Combat.Controllers
{
	public class PlayerController : FighterController
	{
		private PlayerAction currentAction;
		private Fighter currentTarget;
		
		public (PlayerAction, Fighter) GetCurrentAction() {
			return (currentAction, currentTarget);
		}

		public void ChooseAction(CombatManager combatManager) {
			currentAction = new PlayerActionAttack();
			currentTarget = combatManager.fighterEnemy;
			
			combatManager.Continuar();
		}
	}
}