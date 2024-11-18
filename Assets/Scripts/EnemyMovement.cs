using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class EnemyMovement : MonoBehaviour
	{
		[SerializeField] private float movementSpeedPatrolling;
		[SerializeField] private float movementSpeedChasing;
		[SerializeField] private Transform[] movementsPoints;
		[SerializeField] private float distanceMin;
		[SerializeField] private float waitTime;

		private Movement movement;
		private int nextPatrollingPositionNumber;
		private Timer timer;
		private EnemyDetection enemyDetection;

		private void Awake() {
			movement = GetComponent<Movement>();
			Assert.IsNotNull(movement, "Enemy Movement not set");
			enemyDetection = GetComponent<EnemyDetection>();
			Assert.IsNotNull(enemyDetection, "Enemy Detection not set");
			
		}

		private void Start() {
			timer = new Timer(Timer.UpdateType.FIXED_UPDATE);
		}

		private void FixedUpdate() {
			switch (enemyDetection.GetBehaviourState()) {
				case EnemyDetection.BehaviourState.CHASING: MoveChasing(); break;
				case EnemyDetection.BehaviourState.PATROLLING: MovePatrolling(); break;
			}
		}

		private void MovePatrolling() {
			if (movementsPoints.Length > 0 && !timer.IsWaiting()) { //Si no hay puntos, se queda quieto hasta que detecta a alguien
				Transform currentTarget = movementsPoints[nextPatrollingPositionNumber];
				if (Vector2.Distance(transform.position, currentTarget.position) <= distanceMin) {
					nextPatrollingPositionNumber = (nextPatrollingPositionNumber + 1) % movementsPoints.Length;
					currentTarget = movementsPoints[nextPatrollingPositionNumber];

					timer.Wait(waitTime);
				}

				movement.speed = movementSpeedPatrolling;
				movement.MoveNormalized(currentTarget.position - transform.position);
				
				enemyDetection.SetViewAngleOffset(currentTarget.position - transform.position);
			}
		}

		private void MoveChasing() {
			GameObject player = Manager.Instance.player;
			if (player) {
				movement.speed = movementSpeedChasing;
				movement.MoveNormalized(player.transform.position - transform.position);
			}
			
			enemyDetection.SetViewAngleOffset(player.transform.position - transform.position);
		}
		
		public void Wait(float seconds) {
			timer.Wait(seconds);
		}
	}
}