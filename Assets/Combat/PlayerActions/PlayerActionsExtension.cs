using System;
using UnityEngine.Assertions;

namespace Combat
{
	public class PlayerActionsExtension
	{
		public static PlayerAction GetPlayerActionFromEnum(PlayerActions action) {
			switch (action) {
				case PlayerActions.SKIP: return new PlayerActionSkip();
				case PlayerActions.ATTACK: return new PlayerActionAttack();
				case PlayerActions.CHARGING: return new PlayerActionCharge();
				case PlayerActions.STRONG_ATTACK: return new PlayerActionStrongAttack();
				case PlayerActions.STRONG_ATTACK_START: return new PlayerActionStrongAttackStart();
			}

			throw new Exception("Can't parse action. This should never happen");
		}
	}
}