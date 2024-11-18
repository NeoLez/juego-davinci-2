using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float viewRange = 6;
    Vector2 viewDirection = Vector2.left;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Manager.Instance.player)
        {
            Life life = collision.gameObject.GetComponent<Life>();
            life.TakeDamage();
        }
        
    }

    Vector2 targetPosition;

    private void Update()
    {
        if (Vector3.Distance(Manager.Instance.player.transform.position, transform.position) <= viewRange)
        {

        }
    }
}
