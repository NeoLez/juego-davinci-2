using System;
using UnityEngine;

namespace New
{
	public class EnemyDetection : MonoBehaviour
	{
		private BehaviourState state = BehaviourState.PATROLLING;
		[SerializeField] private bool showViewCone = false;
		[SerializeField] private bool showViewDetectionSphere = false;
		[SerializeField] [Range(0, 50)] private float viewDetectionRadius = 10;
		[SerializeField] [Range(0, 2 * Mathf.PI)] private float viewDetectionAngle = 60;
		[SerializeField] [Range(-Mathf.PI, Mathf.PI)] private double viewDetectionAngleOffset = 0;
		[SerializeField] [Range(3, 100)] private int gizmoResolution = 3;
		

		private void FixedUpdate() {
			Vector2 vectorToPlayer = Manager.Instance.player.transform.position - transform.position;
			if (vectorToPlayer.magnitude <= viewDetectionRadius) {
				double angle = vectorToPlayer.GetAngle();

				double offsetAngle = MathUtils.ATan2AngleToNormal(viewDetectionAngleOffset);
				double rightLimitAngle = MathUtils.NormalizeAngle(offsetAngle - viewDetectionAngle/2);
				double leftLimitAngle = MathUtils.NormalizeAngle(offsetAngle + viewDetectionAngle/2);
				
				if (leftLimitAngle > rightLimitAngle) {
					if (angle >= rightLimitAngle && angle <= leftLimitAngle) state = BehaviourState.CHASING;
					else state = BehaviourState.PATROLLING;
				}
				else {
					if(angle <= rightLimitAngle && angle >= leftLimitAngle) state = BehaviourState.PATROLLING;
					else state = BehaviourState.CHASING;
				}
			}
			else {
				state = BehaviourState.PATROLLING;
			}
		}


		public void SetViewAngleOffset(Vector2 v) {
			viewDetectionAngleOffset = v.GetAngle();
		}

		public BehaviourState GetBehaviourState() {
			return state;
		}
		
		public enum BehaviourState
		{
			CHASING,
			PATROLLING,
		}
		
		
		private void OnDrawGizmos()
		{
			if (showViewCone) {
				Vector3[] points = new Vector3[gizmoResolution];
				points[0] = transform.position;
				for (int i = 1; i <= points.Length - 1; i++)
				{
					float angle = (i - 1) * viewDetectionAngle / (gizmoResolution - 2);
					points[i] = transform.position + new Vector3(Mathf.Cos(angle + (float)viewDetectionAngleOffset - viewDetectionAngle / 2), Mathf.Sin(angle + (float)viewDetectionAngleOffset - viewDetectionAngle / 2), 0) * viewDetectionRadius;
				}
				Gizmos.DrawLineStrip(points, true);
			}
			if (showViewDetectionSphere)
			{
				Gizmos.DrawWireSphere(transform.position, viewDetectionRadius);
			}
		}
	}
}