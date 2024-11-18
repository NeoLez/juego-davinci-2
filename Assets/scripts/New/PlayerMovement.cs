using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class PlayerMovement : MonoBehaviour
	{
		private Movement movement;
		private void Awake() {
			movement = GetComponent<Movement>();
			Assert.IsNotNull(movement,"Movement component missing from player - " + gameObject.name);
		}

		private void Update() {
			movement.MoveNormalized(new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")));
		}
	}
}