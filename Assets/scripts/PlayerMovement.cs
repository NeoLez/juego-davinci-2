using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;

    Life PlayerLife;

    [SerializeField]
    float speed;
    [SerializeField]
    public float speedMultiplier = 1f;
    [SerializeField]
    [Range(0f, 1f)]
    float snappiness = 0.01f;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        PlayerLife = GetComponent<Life>();
    }

    Vector3 prevDirection=Vector3.zero;
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y).normalized;
        prevDirection = Vector3.Lerp(prevDirection, direction * speedMultiplier, snappiness);

        if(speedMultiplier!=0)
            rb2D.MovePosition(transform.position + prevDirection * speed * Time.fixedDeltaTime);

    }
}
