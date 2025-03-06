using System;
using Stats;
using UnityEngine;

namespace New
{
    public class TemporaryDamagePowerup : MonoBehaviour
    {
        [SerializeField] private int damageBoost;
        [SerializeField] private float effectDuration;
        [SerializeField] private GameObject feedbackObject;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Manager.Instance.player.GetComponent<PlayerAttack>().damage.AddFlatModifier(new StatFlatModifier(damageBoost, effectDuration));
                GameObject feedback = Instantiate(feedbackObject, Manager.Instance.player.transform);
                feedback.GetComponent<DeleteAfterSeconds>().seconds = effectDuration;
                Destroy(gameObject);
            }
        }
    }
}