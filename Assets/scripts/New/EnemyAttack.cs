using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class EnemyAttack : MonoBehaviour
	{
		[SerializeField] private int attackDamage;
		[SerializeField] private int pushStrength;
		[SerializeField] private AudioClip hitAudio;
		private Movement movement;

		private void Awake() {
			movement = GetComponent<Movement>();
			Assert.IsNotNull(movement, "Movement not found in enemy");
		}

		private void OnCollisionEnter2D(Collision2D collision) {
			GameObject player = collision.gameObject;
			if (collision.gameObject == Manager.Instance.player) {
				Health playerHealth = player.GetComponent<Health>();
				Assert.IsNotNull(playerHealth, "Player has no health component");
				Movement playerMovement = player.GetComponent<Movement>();
				Assert.IsNotNull(playerHealth, "Player has no movement component");
				
				playerHealth.TakeDamage(attackDamage);
				playerMovement.Impulse(((player.transform.position - transform.position).normalized.ToVector2() * pushStrength + movement.GetMoveVector()) * pushStrength);
				
				Manager.Instance.PlaySound(hitAudio, 1);
			}
		}
	}
}