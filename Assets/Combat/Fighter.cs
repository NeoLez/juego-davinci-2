
using Combat;
using Combat.Controllers;

public class Fighter
{
    public string name;
    public Stats stats;
    private FighterController controller=null;

    public Fighter(Stats stats, string name) {
        this.name = name;
        this.stats = stats;
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
