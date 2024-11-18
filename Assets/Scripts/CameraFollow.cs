using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class CameraFollow : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;
		[SerializeField] private float snappiness;
		[SerializeField] private float lookAheadIntensityStill;
		[SerializeField] private float lookAheadIntensityMove;
		[SerializeField] private GameObject camera;

		private Movement playerMovement;

		private void Awake() {
			playerMovement = gameObject.GetComponent<Movement>();
			Assert.IsNotNull(playerMovement, "Player does not have a movement component");
		}

		private void FixedUpdate() {
			camera.transform.position = Vector3.Lerp(camera.transform.position, Manager.Instance.player.transform.position + offset + playerMovement.GetLastMoveVector().ToVector3() * lookAheadIntensityStill + playerMovement.GetDirectionVector().ToVector3() * lookAheadIntensityMove, snappiness * Time.deltaTime);
		}
	}
}