using System;
using UnityEngine;

namespace New
{
	public class BasicDialogController : MonoBehaviour
	{
		[SerializeField] private Dialogue _dialogue;

		private void Update() {
			if (_dialogue.IsPlayerInRange() && Input.GetKeyDown(KeyCode.F)) { ;
				_dialogue.Interact();
			}
		}
	}
}