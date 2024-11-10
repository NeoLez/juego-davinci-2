using System;
using UnityEngine;

namespace Combat
{
	public abstract class PlayerAction
	{
	    public abstract bool MeetsRequirements(CombatManager combatManager, Fighter target, Fighter actor);
		public abstract void Run(CombatManager combatManager, Fighter target, Fighter actor);
	}
}