using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Rigidbody2D rb2D;
    float bufferWindow = 0.5f;
    float cooldown = 0f;
    float lastAttackTime;
    int attackNumber = 0;
    bool buffered = false;

    Vector3 attackMovementDestination;
    bool moveTowardDestination = false;

    PlayerMovement playerMovement;
    private void Start()
    {
        lastAttackTime = Time.time;
        playerMovement = GetComponent<PlayerMovement>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Debug.Log(Time.time - lastAttackTime);
        if (Time.time - lastAttackTime >= cooldown)
        {
            moveTowardDestination = false;
            if (Input.GetMouseButtonDown(0) || buffered)
            {
                //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Vector2 viewVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                viewVector.Normalize();
                float viewVectorAngle = Vector2.Angle(Vector2.zero,viewVector);
                buffered = false;
                lastAttackTime = Time.time;
                switch (attackNumber)
                {
                    case 0:
                        Debug.Log("Ataque 1");
                        playerMovement.speedMultiplier = 0.7f;
                        cooldown = 0.6f;
                        attackNumber = 1;
                        Attack(2, (Vector2)transform.position+viewVector, new Vector2(2,1), viewVectorAngle);
                        break;
                    case 1:
                        Debug.Log("Ataque 2");
                        playerMovement.speedMultiplier = 0.2f;
                        cooldown = 0.6f;
                        attackNumber = 2;
                        Attack(3, (Vector2)transform.position + viewVector, new Vector2(2, 1), viewVectorAngle);
                        break;
                    case 2:
                        Debug.Log("Ataque 3");
                        cooldown = 1.2f;
                        playerMovement.speedMultiplier = 0.0f;
                        attackNumber = 0;

                        attackMovementDestination = viewVector* 4;
                        attackMovementDestination += transform.position;
                        moveTowardDestination = true;

                        Attack(5, (Vector2)transform.position + viewVector*2f, new Vector2(4, 1), viewVectorAngle);

                        break;
                    default:
                        Debug.Log("Something broke in the player attack script");
                        attackNumber = 0;
                        break;
                }
            }
            else
            {
                playerMovement.speedMultiplier = 1f;
                attackNumber = 0;
            }
        }else
        {
            if (Time.time - lastAttackTime >= cooldown - bufferWindow && Input.GetMouseButtonDown(0))
                buffered = true;

            if (moveTowardDestination)
            {
                //Debug.Log(attackMovementDestination);
                rb2D.MovePosition(Vector3.Lerp(transform.position, attackMovementDestination, Time.fixedDeltaTime*7));
            }
        }
    }


    private void Attack(int damage, Vector2 attackCenter, Vector2 size, float angle)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(attackCenter, size, angle);
        Debug.Log(hits.Length);
        foreach (Collider2D hit in hits) {
            if (hit.gameObject.TryGetComponent<Life>(out Life life))
            {
                life.TakeDamage(damage);
            }
        }
    }

}
