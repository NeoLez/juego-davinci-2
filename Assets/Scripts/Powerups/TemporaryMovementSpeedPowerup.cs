using System;
using Stats;
using UnityEngine;

namespace New
{
    public class TemporaryMovementSpeedPowerup : MonoBehaviour
    {
        [SerializeField] private float percentualIncrease;
        [SerializeField] private float effectDuration;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Manager.Instance.player.GetComponent<Movement>().speed.AddPercentageModifier(new StatPercentageModifier(percentualIncrease, effectDuration));
                Destroy(gameObject);
            }
        }
    }
}