using UnityEngine;

public class CombatManager
{
	//public const int MAX_PERSONAJES=2;
	public Fighter fighterPlayer;
	public Fighter fighterEnemy;
	
	public CombatManager(Fighter fighterPlayer, Fighter fighterEnemy, bool goodStarts) {
		this.fighterEnemy = fighterEnemy;
		this.fighterPlayer = fighterPlayer;
		
		if (goodStarts) {
			fighter = fighterPlayer;
			this.fighterPlayer.ChooseAction(this);
		}
		else {
			fighter = fighterEnemy;
			this.fighterEnemy.ChooseAction(this);
		}
		
		LogInfo();
	}

	private bool checkingPlayerFighter = false;
	Fighter fighter;
	public void Continuar() {
		var (action, target) = fighter.GetCurrentAction();
		Debug.Log($"Evaluating {fighter.characterData.name}'s turn");
		//Assert.IsTrue(action.MeetsRequirements(this, target, fighter), "A controller didn't do their homework ;c");
		
		action.Run(this, target, fighter);
		
		LogInfo();
		
		
		if (HasPlayerWon()) {
			Debug.Log("Player won yay");
			//DO SOMETHING HERE
			return;
		}
		if (HasPlayerLost()) {
			Debug.Log("Player lost :c");
			//DO SOMETHING HERE
			return;
		}
		
		
		if (checkingPlayerFighter) {
			fighter = fighterEnemy;
		}
		else {
			fighter = fighterPlayer;
		}
		checkingPlayerFighter = !checkingPlayerFighter;
		
		fighter.ChooseAction(this);
	}

	bool HasPlayerWon() {
		return !fighterEnemy.IsAlive();
	}
	bool HasPlayerLost() {
		return !fighterPlayer.IsAlive();
	}

	void LogInfo() {
		Debug.Log($"<color=#ffe59e>{fighterEnemy.characterData.name}: {fighterEnemy.stats}</color>");
		Debug.Log($"<color=#ffe59e>{fighterPlayer.characterData.name}: {fighterPlayer.stats}</color>");
	}
}
        
