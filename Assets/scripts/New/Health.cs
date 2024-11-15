﻿using UnityEngine;

namespace New
{
	public class Health : MonoBehaviour
	{
		[SerializeField]
		private int currentLife = 5;

		public void TakeDamage(int damage = 1)
		{
			currentLife -= damage;
			if (currentLife <= 0)
			{
				Destroy(gameObject);
			}
		}

		public void Heal(int amount)
		{
			currentLife += amount;
			Debug.Log("Vida recuperada. Vida actual: " + currentLife);
		}
	}
}