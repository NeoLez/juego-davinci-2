namespace Combat.Controllers
{
	public interface FighterController
	{
		(PlayerAction, Fighter) GetCurrentAction();
		void ChooseAction(CombatManager combatManager);
	}
}