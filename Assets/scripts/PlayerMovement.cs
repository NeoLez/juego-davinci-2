using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private Movement movement;

		private void Update() {
			movement.MoveNormalized(new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")));
		}
	}
}