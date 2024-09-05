using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private int currentLife = 5;

    public void TakeDamage()
    {
        if (currentLife > 0)
        {
            currentLife--;
        }
        else 
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
