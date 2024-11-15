using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class Movement : MonoBehaviour
	{
		[SerializeField] public float speed = 10f;
		[SerializeField] private float snappiness = 0.01f;
		[SerializeField] private float pushSnappinessBase = 0.01f;
		
		private Rigidbody2D rb;
		private Vector2 movementVector = Vector2.zero;
		private Vector2 prevDirection=Vector3.zero;
		private Vector2 pushDirection =Vector3.zero;
		private Vector2 prevPushDirection = Vector2.zero;
		private float pushSnappiness = 0.01f;
		private Vector2 lastMovementDirection = Vector2.zero;
		private bool isMoving;
		
		private void Start() {
			rb = GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rb, "Player does not have a RigidBody attached");
		}

		private void FixedUpdate() {
			
			prevDirection = Vector2.Lerp(prevDirection, movementVector, snappiness);
			if (movementVector != Vector2.zero) {
				isMoving = true;
				lastMovementDirection = movementVector;
				movementVector = Vector2.zero;
			}
			else {
				isMoving = false;
			}
			
			
			
			if (pushDirection != Vector2.zero) {
				prevPushDirection = pushDirection;
				pushDirection = Vector2.zero;
			}
			prevPushDirection = Vector2.Lerp(prevPushDirection, Vector2.zero, pushSnappiness);

			rb.MovePosition(transform.position + ((prevDirection.ToVector3() * speed) + prevPushDirection.ToVector3()) * Time.fixedDeltaTime);
		}

		public void Impulse(Vector2 direction) {
			pushDirection = direction;
			//pushSnappiness = pushSnappinessBase / pushDirection.magnitude; //No me gusta esto pero bueno xd
			pushSnappiness = 0.1f;
		}

		public void MoveNormalized(Vector2 direction) {
			movementVector = direction.normalized;
		}

		public void Move(Vector2 direction) {
			movementVector = direction;
		}

		public Vector2 GetDirectionVector() {
			return prevDirection + Vector2.zero;
		}
		public Vector2 GetMoveVector() {
			return GetDirectionVector() * speed;
		}

		public Vector2 GetLastMoveVector() {
			return lastMovementDirection.normalized;
		}

		public bool IsMoving() {
			return isMoving;
		}
	}
}