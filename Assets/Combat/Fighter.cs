
using Combat;
using Combat.Controllers;

public class Fighter
{
    public string name;
    public Stats stats;
    private FighterController controller;

    public Fighter(Stats stats, FighterController controller, string name) {
        this.name = name;
        this.stats = stats;
        this.controller = controller;
    }

    public void SetController(FighterController controller) {
        this.controller = controller;
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
