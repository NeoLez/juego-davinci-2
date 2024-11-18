using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField]
    private int healAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Life playerLife = collision.gameObject.GetComponent<Life>();

        if (playerLife != null)
        {
            playerLife.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
