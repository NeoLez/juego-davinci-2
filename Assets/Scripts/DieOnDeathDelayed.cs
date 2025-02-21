using System.Collections.Generic;
using UnityEngine;

namespace New
{
	public class DieOnDeathDelayed : MonoBehaviour
	{
		[SerializeField] private Health health;
		[SerializeField] private float delay;
		[SerializeField] private List<GameObject> gameObjectsToDisable;
		[SerializeField] private List<Behaviour> componentsToDisable;

		private void Start() {
			health.OnDeathEvent += Die;
		}

		private void Die() {
			foreach (var obj in gameObjectsToDisable)
			{
				obj.SetActive(false);
			}
			foreach (var component in componentsToDisable)
			{
				component.enabled = false;
			}
			Invoke(nameof(DestroyObject), delay);
		}

		private void DestroyObject()
		{
			Destroy(gameObject);
		}
	}
}