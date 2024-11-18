using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace New
{
	public class DieOnDeath : MonoBehaviour
	{
		[SerializeField] private Health health;

		private void Start() {
			health.OnDeathEvent += Die;
		}

		private void Die(object sender, EventArgs args) {
			Destroy(gameObject);
		}
	}
}