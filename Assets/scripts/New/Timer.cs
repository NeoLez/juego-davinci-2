using UnityEngine;
using UnityEngine.Assertions;

namespace New
{
	public class Timer
	{
		private float timerSeconds;

		/***
		 * ALWAYS INSTANTIATE IN START AS IT DEPENDS ON A MANAGER GAMEOBJECT EXISTING
		 */
		public Timer(UpdateType type) {
			switch (type) {
				case UpdateType.UPDATE: {Manager.Instance.UpdateEvent += CountTime;} break;
				case UpdateType.FIXED_UPDATE: {Manager.Instance.FixedUpdateEvent += CountTime;} break;
				default: Debug.LogError("Unexpected value in Timer"); break;
			}
		}

		private void CountTime(object sender, Manager.DeltaTimeEventArgs args) {
			timerSeconds -= args.deltaTime;
		}
		
		public bool IsWaiting() {
			return timerSeconds > 0;
		}

		public void Wait(float seconds) {
			timerSeconds = seconds;
		}

		public enum UpdateType
		{
			UPDATE,
			FIXED_UPDATE,
		}
	}
}