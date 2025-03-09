using System;
using UnityEngine;

namespace New
{
	public class BasicDialogController : MonoBehaviour
	{
		[SerializeField] private Dialogue _dialogue;
		private bool isPlayerInRange;

		private void Start() {
			Manager.Instance.playerInput.OnPressedInteract += Interacted;
		}

		public void Interacted() {
			if (isPlayerInRange) { ;
				_dialogue.Interact();
			}
		}
		
		
		private void OnTriggerEnter2D(Collider2D Collision)
		{
			if (Manager.Instance.player == Collision.gameObject)
			{
				isPlayerInRange = true;
				_dialogue.SetDialogMarkState(true);
			}

		}
		private void OnTriggerExit2D(Collider2D Collision)
		{
			if (Manager.Instance.player == Collision.gameObject)
			{
				isPlayerInRange = false;
				_dialogue.SetDialogMarkState(false);
			}
		}
	}
}