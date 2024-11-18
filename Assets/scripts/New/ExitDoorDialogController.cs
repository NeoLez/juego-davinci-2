using UnityEngine;
using UnityEngine.SceneManagement;

namespace New
{
	public class ExitDoorDialogController : MonoBehaviour
	{
		[SerializeField] private Dialogue dialogDoorClosed;
		[SerializeField] private Dialogue dialogDoorOpen;
		[SerializeField] private AudioClip doorOpenAudio;
		[SerializeField] private AudioClip doorCloseAudio;
		private bool isPlayerInRange;
		
		private bool isDoorOpen;
		private bool lockState;
		private bool playedSound;
		
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
					if (!playedSound) {
						Manager.Instance.PlaySound(doorOpenAudio, 1);
						playedSound = true;
					}

					lockState = dialogDoorOpen.Interact();
					if (!lockState) {
						SceneManager.LoadScene("Victory");
					}
				}
				else {
					if (!playedSound) {
						Manager.Instance.PlaySound(doorCloseAudio, 1);
						playedSound = true;
					}

					lockState = dialogDoorClosed.Interact();
					if (!lockState) {
						playedSound = false;
					}
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