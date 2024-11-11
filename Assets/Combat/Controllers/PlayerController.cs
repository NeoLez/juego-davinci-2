using UnityEngine;

namespace Combat.Controllers
{
	public class PlayerController : MonoBehaviour, FighterController
	{
		private Fighter controlledFighter;
		private PlayerAction currentAction;
		private Fighter currentTarget;
		CombatManager manager;
		private Canvas canvas;

        private void Start()
        {
            canvas = GetComponent<Canvas>();
        }

		public void setFighter(Fighter fighter)
		{
			controlledFighter = fighter;
		}

        //public PlayerController(Fighter controlledFighter) {
		//	this.controlledFighter = controlledFighter;
		//}
		
		public (PlayerAction, Fighter) GetCurrentAction() {
			return (currentAction, currentTarget);
		}

		public void ChooseAction(CombatManager combatManager) {
			currentTarget = combatManager.fighterEnemy;
			manager = combatManager;
			
			canvas.enabled = true;
		}

		public void ChooseActionAttack()
		{
			currentAction = new PlayerActionAttack();
            canvas.enabled = false;
            manager.Continuar();
        }
        public void ChooseActionAttackHeavy()
        {
            currentAction = new PlayerActionStrongAttackStart();
            canvas.enabled = false;
            manager.Continuar();
        }
        public void ChooseActionSkip()
        {
            currentAction = new PlayerActionSkip();
			canvas.enabled = false;
            manager.Continuar();
        }
    }
}