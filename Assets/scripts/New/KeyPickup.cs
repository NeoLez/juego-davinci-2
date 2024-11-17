using System;
using UnityEngine;

namespace New
{
	public class KeyPickup : MonoBehaviour
	{
		private bool canInteract;

		[SerializeField]
		private int keyNumber;

		private void Update() {
			if (canInteract && Input.GetKey(KeyCode.F)) {
				switch (keyNumber) {
					case 1: Manager.Instance.foundKeyOne = true; break;
					case 2: Manager.Instance.foundKeyTwo = true; break;
				}
				Destroy(gameObject);
			}
		}

		private void OnTriggerEnter2D(Collider2D colliding) {
			if (colliding.gameObject == Manager.Instance.player) {
				canInteract = true;
			}
		}
		private void OnTriggerExit2D(Collider2D colliding) {
			if (colliding.gameObject == Manager.Instance.player) {
				canInteract = true;
			}
		}
	}
}