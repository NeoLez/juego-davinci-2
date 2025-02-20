using System;
using Stats;
using UnityEngine;

namespace New
{
    public class TemporaryDamagePowerup : MonoBehaviour
    {
        [SerializeField] private int damageBoost;
        [SerializeField] private float effectDuration;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Manager.Instance.player.GetComponent<PlayerAttack>().damage.AddFlatModifier(new StatFlatModifier(damageBoost, effectDuration));
                Destroy(gameObject);
            }
        }
    }
}