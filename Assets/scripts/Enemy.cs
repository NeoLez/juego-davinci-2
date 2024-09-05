using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Life life = collision.gameObject.GetComponent<Life>();

        life.TakeDamage();


    }
}
