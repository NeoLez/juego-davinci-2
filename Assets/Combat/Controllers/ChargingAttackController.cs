namespace Combat.Controllers
{
	public class ChargingAttackController : FighterController
	{
		private Fighter controlledFighter;
		private PlayerActions action;
		private int numberOfTurns;
		private FighterController prevController;

		private (PlayerAction, Fighter) a;

		public ChargingAttackController(Fighter controlledFighter, PlayerActions action, int numberOfTurns, FighterController prevController) {
			this.action = action;
			this.numberOfTurns = numberOfTurns;
			this.prevController = prevController;
			this.controlledFighter = controlledFighter;
		}


		public (PlayerAction, Fighter) GetCurrentAction() {
			if (numberOfTurns > 0) {
				return a;
			}
			
			controlledFighter.SetController(prevController);
			return (PlayerActionsExtension.GetPlayerActionFromEnum(action), a.Item2);
		}

		public void ChooseAction(CombatManager combatManager) {
			a = (PlayerActionsExtension.GetPlayerActionFromEnum(PlayerActions.CHARGING), combatManager.fighterEnemy);
			numberOfTurns--;
			combatManager.Continuar();
		}
	}
}