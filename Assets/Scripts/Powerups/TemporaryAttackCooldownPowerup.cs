using Stats;
using UnityEngine;
using UnityEngine.Serialization;

namespace New
{
    public class TemporaryAttackCooldownPowerup : MonoBehaviour
    {
        [SerializeField] private float percentage;
        [SerializeField] private float effectDuration;
        [SerializeField] private GameObject feedbackObject;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Manager.Instance.player.GetComponent<PlayerAttack>().attackCooldown.AddPercentageModifier(new StatPercentageModifier(percentage, effectDuration));
                GameObject feedback = Instantiate(feedbackObject, Manager.Instance.player.transform);
                feedback.GetComponent<DeleteAfterSeconds>().seconds = effectDuration;
                Destroy(gameObject);
            }
        }
    }
}