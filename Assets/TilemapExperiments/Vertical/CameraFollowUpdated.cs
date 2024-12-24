using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class CameraFollowUpdated : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;
		[SerializeField] private float snappiness;
		[SerializeField] private float lookAheadIntensityStill;
		[SerializeField] private float lookAheadIntensityMove;
		[SerializeField] private GameObject camera;

		private MovementUpdated playerMovement;

		private void Awake() {
			playerMovement = gameObject.GetComponent<MovementUpdated>();
			Assert.IsNotNull(playerMovement, "Player does not have a movement component");
		}

		private void FixedUpdate() {
			Vector3 newpos = Vector3.Lerp(camera.transform.position, Manager.Instance.player.transform.position + offset + playerMovement.GetLastMoveVector().ToVector3() * lookAheadIntensityStill + playerMovement.GetDirectionVector().ToVector3() * lookAheadIntensityMove, snappiness * Time.deltaTime);
			camera.transform.position = new Vector3(newpos.x, newpos.y, camera.transform.position.z);
		}
	}
}