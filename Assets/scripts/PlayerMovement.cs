using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private Movement movement;

		private void Update() {
			movement.MoveNormalized(Manager.Instance.playerInput.GetMovementDirection());
		}
	}
}