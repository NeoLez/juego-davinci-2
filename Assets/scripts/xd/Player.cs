using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;

    Life PlayerLife;

    [SerializeField]
    float speed;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        PlayerLife = GetComponent<Life>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y).normalized;

        rb2D.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

    }
}
