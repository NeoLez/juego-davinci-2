
using UnityEngine;

namespace New
{
	public class PlayerMovementUpdated : MonoBehaviour
	{
		[SerializeField] private MovementUpdated movement;

		private void Update() {
			movement.MoveNormalized(new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")));
		}
	}
}