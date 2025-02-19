using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class EnemyMovementRanged : MonoBehaviour
	{
		[SerializeField] private float movementSpeedPatrolling;
		[SerializeField] private float movementSpeedChasing;
		[SerializeField] private float movementSpeedFleeing;
		[SerializeField] private float attackDistance;
		[SerializeField] private float fleeDistance;
		[SerializeField] private float shootCooldown;
		[SerializeField] private float healCooldown;
		[SerializeField] private int fleeHealth;
		[SerializeField] private Transform[] movementsPoints;
		[SerializeField] private float distanceMin;
		[SerializeField] private float waitTime;

		private Movement movement;
		private Health health;
		private int nextPatrollingPositionNumber;
		private Timer patrolWaitTimer;
		private Timer healTimer;
		private Timer shootTimer;
		private EnemyDetection enemyDetection;

		private void Awake() {
			movement = GetComponent<Movement>();
			Assert.IsNotNull(movement, "Enemy Movement not set");
			enemyDetection = GetComponent<EnemyDetection>();
			Assert.IsNotNull(enemyDetection, "Enemy Detection not set");
			health = GetComponent<Health>();
			Assert.IsNotNull(health, "Health not set");
		}

		private void Start() {
			patrolWaitTimer = new Timer(Timer.UpdateType.FIXED_UPDATE);
		}

		private void FixedUpdate() {
			if (healTimer != null)
			{
				if (!healTimer.IsWaiting())
				{
					Debug.Log("El men se curo");
					healTimer = null;
				}
			}else if (shootTimer != null)
			{
				if (!shootTimer.IsWaiting())
				{
					Debug.Log("El men disparo");
					shootTimer = null;
				}
			}
			else
			{
				switch (enemyDetection.GetBehaviourState()) {
					case EnemyDetection.BehaviourState.CHASING: MoveChasing(); break;
					case EnemyDetection.BehaviourState.PATROLLING: MovePatrolling(); break;
				}
			}
		}

		private void MovePatrolling() {
			if (movementsPoints.Length > 0 && !patrolWaitTimer.IsWaiting()) { //Si no hay puntos, se queda quieto hasta que detecta a alguien
				Transform currentTarget = movementsPoints[nextPatrollingPositionNumber];
				if (Vector2.Distance(transform.position, currentTarget.position) <= distanceMin) {
					nextPatrollingPositionNumber = (nextPatrollingPositionNumber + 1) % movementsPoints.Length;
					currentTarget = movementsPoints[nextPatrollingPositionNumber];

					patrolWaitTimer.Wait(waitTime);
				}

				movement.speed.SetBaseValue(movementSpeedPatrolling);
				movement.MoveNormalized(currentTarget.position - transform.position);
				
				enemyDetection.SetViewAngleOffset(currentTarget.position - transform.position);
			}
		}

		private void MoveChasing() {
			GameObject player = Manager.Instance.player;
			if (player) {
				Vector2 vectorToPlayer = player.transform.position - transform.position;
				if (health.GetHealth() > fleeHealth) //Normal Attack Behaviour
				{
					movement.speed.SetBaseValue(movementSpeedChasing);
					if (attackDistance < vectorToPlayer.magnitude)
					{
						movement.MoveNormalized(player.transform.position - transform.position);
					}
					else
					{
						shootTimer = new Timer(Timer.UpdateType.UPDATE);
						shootTimer.Wait(shootCooldown);
					}
				}
				else //Flee
				{
					movement.speed.SetBaseValue(movementSpeedFleeing);
					if (fleeDistance > vectorToPlayer.magnitude)
					{
						movement.MoveNormalized( transform.position - player.transform.position);
					}
					else
					{
						healTimer = new Timer(Timer.UpdateType.UPDATE);
						healTimer.Wait(healCooldown);
					}
				}
			}
			
			enemyDetection.SetViewAngleOffset(player.transform.position - transform.position);
		}
		
		public void Wait(float seconds) {
			patrolWaitTimer.Wait(seconds);
		}
	}
}