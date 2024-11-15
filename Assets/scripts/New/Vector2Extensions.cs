using System;
using UnityEngine;

namespace New
{
	public static class Vector2Extensions
	{
		public static Vector3 ToVector3(this Vector2 v) {
			return new Vector3(v.x, v.y, 0);
		}

		public static double GetAngle(this Vector2 v) {
			return MathUtils.ATan2AngleToNormal(Math.Atan2(v.y, v.x));
		}
	}
}