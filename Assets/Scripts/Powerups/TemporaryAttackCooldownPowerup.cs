using Stats;
using UnityEngine;

namespace New
{
    public class TemporaryAttackCooldownPowerup : MonoBehaviour
    {
        [SerializeField] private float percentage;
        [SerializeField] private float effectDuration;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Manager.Instance.player.GetComponent<PlayerAttack>().attackCooldown.AddPercentageModifier(new StatPercentageModifier(percentage, effectDuration));
                Destroy(gameObject);
            }
        }
    }
}