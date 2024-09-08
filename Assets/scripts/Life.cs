using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private int currentLife = 5;

    public void TakeDamage(int damage = 1)
    {
        currentLife -= damage;
        if (currentLife <= 0)
        {
            Debug.Log("jaja moriste");
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        currentLife += amount;
        Debug.Log("Vida recuperada. Vida actual: " + currentLife);
    }
}
