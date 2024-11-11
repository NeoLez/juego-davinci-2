
using Combat;
using Combat.Controllers;
using Unity.VisualScripting;
using UnityEngine;

public class Fighter
{
    public CharacterDataSO characterData;
    public Stats stats;
    private FighterController controller=null;

    public Fighter(CharacterDataSO enemyData) {
        this.characterData = enemyData;
        this.stats = enemyData.BaseStats.Clone();
    }

    public void SetController(FighterController controller) {
        this.controller = controller;
    }
    public FighterController GetController() {
        return controller;
    }
    //void SetCurrentAction(PlayerAction playerAction, IFighter target);
    public (PlayerAction, Fighter) GetCurrentAction() {
        return controller.GetCurrentAction();
    }
    public void ChooseAction(CombatManager combatManager) {
        controller.ChooseAction(combatManager);
    }
    public bool IsAlive() {
        return stats.Health > 0;
    }
}
