using UnityEngine;
using UnityEngine.SceneManagement;

namespace New.Materials
{
	public class ExitDoorDialogController : MonoBehaviour
	{
		[SerializeField] private Dialogue dialogDoorClosed;
		[SerializeField] private Dialogue dialogDoorOpen;
		private bool isPlayerInRange;
		
		private bool isDoorOpen;
		private bool lockState;
		
		private void Update() {
			if (!lockState) {
				if (Manager.Instance.foundKeyOne && Manager.Instance.foundKeyTwo) {
					isDoorOpen = true;
				}
				else {
					isDoorOpen = false;
				}
			}

			if (isPlayerInRange && Input.GetKeyDown(KeyCode.F)) {
				lockState = true;
				if (isDoorOpen) {
					lockState = dialogDoorOpen.Interact();
					if (!lockState) {
						SceneManager.LoadScene("Victoria");
					}
				}
				else {
					lockState = dialogDoorClosed.Interact();
				}
			}
		}
		
		
		private void OnTriggerEnter2D(Collider2D Collision)
		{
			if (Manager.Instance.player == Collision.gameObject)
			{
				isPlayerInRange = true;
				dialogDoorOpen.SetDialogMarkState(true);
			}

		}
		private void OnTriggerExit2D(Collider2D Collision)
		{
			if (Manager.Instance.player == Collision.gameObject)
			{
				isPlayerInRange = false;
				dialogDoorOpen.SetDialogMarkState(false);
			}
		}
	}
}