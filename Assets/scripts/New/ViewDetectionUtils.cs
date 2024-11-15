using System;
using UnityEngine;

namespace New
{
	public static class ViewDetectionUtils
	{
		public static bool IsInSight(GameObject actor, GameObject target) {
			RaycastHit2D[] hits = Physics2D.RaycastAll(actor.transform.position, target.transform.position - actor.transform.position);
			Array.Sort(hits, (a, b) => (a.distance.CompareTo(b.distance)));

			foreach (RaycastHit2D hit in hits)
			{

				if (hit.collider.gameObject.layer == 8)
				{
					break;
				}

				if (hit.collider.gameObject == target) {
					return true;
				}
			}

			return false;
		}
		
	}
}