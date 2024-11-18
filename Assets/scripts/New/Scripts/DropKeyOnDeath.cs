using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace New
{
	public class DropKeyOnDeath : MonoBehaviour
	{
		[SerializeField] private GameObject keyPrefab;
		[SerializeField] private Health health;

		private void Start() {
			health.OnDeathEvent += DropKey;
		}

		private void DropKey(object sender, EventArgs args) {
			GameObject key = Instantiate(keyPrefab);
			key.transform.position = transform.position;
			key.GetComponent<Movement>().Impulse(Random.insideUnitCircle * 7);
			Destroy(gameObject);
		}
	}
}