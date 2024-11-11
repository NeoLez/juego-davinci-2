using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform[] movementsPoints;

    [SerializeField]
    private float distanceMin;

    private int randomNumber;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        randomNumber = Random.Range(0, movementsPoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movementsPoints[randomNumber].position, movementSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movementsPoints[randomNumber].position) < distanceMin)
        {
            randomNumber = Random.Range(0, movementsPoints.Length);
            Girar();
        }

    }

    private void Girar()    
    {
        if (transform.position.x < movementsPoints[randomNumber].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }


    }
}
