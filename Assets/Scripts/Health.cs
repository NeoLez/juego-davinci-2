using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace New
{
	public class Health : MonoBehaviour
	{
		[SerializeField] private int currentLife = 5;
		[SerializeField] private AudioClip hitSound;
		[SerializeField] private AudioClip deathSound;
		public event Action OnDeathEvent;
		public event Action OnHitEvent;

		public void TakeDamage(int damage = 1)
		{
			currentLife -= damage;
			
			if (currentLife <= 0)
			{
				if(deathSound)
					Manager.Instance.PlaySound(deathSound);
				OnDeathEvent?.Invoke();
			}
			else
			{
				if(hitSound)
					Manager.Instance.PlaySound(hitSound);
			}
			OnHitEvent?.Invoke();
		}

		public void Heal(int amount)
		{
			currentLife += amount;
		}

		public int GetHealth() {
			return currentLife;
		}
	}
}