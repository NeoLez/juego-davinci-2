using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class TurretProjectile : MonoBehaviour
	{
		[SerializeField] private float speed;
		[SerializeField] private float lifetime;
		[SerializeField] private float knockbackAmount;
		[SerializeField] private int damage;
		private Rigidbody2D rb;
		private Timer lifeTimer;

		private void Start() {
			lifeTimer = new Timer(Timer.UpdateType.FIXED_UPDATE);
			lifeTimer.Wait(lifetime);
		}

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rb, "Rigidbody not set for turret projectile");
		}

		private void FixedUpdate() {
			if (!lifeTimer.IsWaiting()) {
				Destroy(gameObject);
			}
			rb.MovePosition(transform.position + transform.right * (speed * Time.fixedDeltaTime));
		}

		private void OnTriggerEnter2D(Collider2D collider2D) {
			if (collider2D.gameObject == Manager.Instance.player) {
				Health playerHealth = collider2D.gameObject.GetComponent<Health>();
				Movement playerMovement = collider2D.gameObject.GetComponent<Movement>();
				Assert.IsNotNull(playerHealth, "Player doesn't have a Health component");
				Assert.IsNotNull(playerMovement, "Player doesn't have a Movement component");
				
				playerHealth.TakeDamage(damage);
				playerMovement.Impulse(transform.right * knockbackAmount);
				Destroy(gameObject);
			}
			
			if (collider2D.gameObject.layer == 8) {
				Destroy(gameObject);
			}
		}
	}
}