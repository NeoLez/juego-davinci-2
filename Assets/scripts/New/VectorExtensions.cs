using System;
using UnityEngine;

namespace New
{
	public static class VectorExtensions
	{
		public static Vector3 ToVector3(this Vector2 v) {
			return new Vector3(v.x, v.y, 0);
		}
		public static Vector2 ToVector2(this Vector3 v) {
			return v;
		}

		public static double GetAngle(this Vector2 v) {
			return MathUtils.ATan2AngleToNormal(Math.Atan2(v.y, v.x));
		}
	}
}