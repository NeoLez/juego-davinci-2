using System;
using UnityEngine;

namespace New
{
	public class TurretEnemy : MonoBehaviour
	{
		[SerializeField] private float activationDistance;
		[SerializeField] private bool showViewDetectionSphere;
		[SerializeField] private GameObject turretProjectile;
		[SerializeField] private Vector2 offset;
		[SerializeField] private float shootCooldown = 0.5f;
		private float currentShootCooldown;

		private void FixedUpdate() {
			currentShootCooldown -= Time.fixedDeltaTime;
			
			if (currentShootCooldown <= 0) {
				GameObject player = Manager.Instance.player;
				if ((player.transform.position - transform.position).magnitude <= activationDistance && ViewDetectionUtils.IsInSight(gameObject, Manager.Instance.player)) {
					GameObject projectile = Instantiate(turretProjectile);
					projectile.transform.position = transform.position + offset.ToVector3();

					Vector2 targetDirection = player.transform.position - transform.position;
					float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
					projectile.transform.eulerAngles = new Vector3(0, 0, angle);
					
					currentShootCooldown = shootCooldown;
				}
			}
		}
		
		private void OnDrawGizmos()
		{
			if (showViewDetectionSphere)
			{
				Gizmos.DrawWireSphere(transform.position, activationDistance);
			}
		}
	}
}