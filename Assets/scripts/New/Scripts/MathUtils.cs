using System;

namespace New
{
	public static class MathUtils
	{
		public static double NormalizeAngle(double angle) {
			return angle - Math.PI*2*Math.Floor(angle/(Math.PI*2));;
		}
		public static double ATan2AngleToNormal(double angle) {
			if (angle < 0) {
				angle += Math.PI * 2;
			}
			return angle;
		}
	}
}