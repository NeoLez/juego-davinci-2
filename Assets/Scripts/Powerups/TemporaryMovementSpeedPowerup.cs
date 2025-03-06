using System;
using Stats;
using UnityEngine;

namespace New
{
    public class TemporaryMovementSpeedPowerup : MonoBehaviour
    {
        [SerializeField] private float percentualIncrease;
        [SerializeField] private float effectDuration;
        [SerializeField] private GameObject feedbackObject;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Manager.Instance.player.GetComponent<Movement>().speed.AddPercentageModifier(new StatPercentageModifier(percentualIncrease, effectDuration));
                GameObject feedback = Instantiate(feedbackObject, Manager.Instance.player.transform);
                feedback.GetComponent<DeleteAfterSeconds>().seconds = effectDuration;
                Destroy(gameObject);
            }
        }
    }
}