using System;
using New;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

public class FireballProjectile : MonoBehaviour
{
    [SerializeField] public float angle;
    [SerializeField] public float lifetime;
    [SerializeField] public float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private float knockbackAmount;
    [SerializeField] private AudioClip hitSound;
    public int damage;
    [SerializeField] private Rigidbody2D rb;
    private float startTime;
    private Vector3 startPosition;
    private Vector2 currentDirection = Vector2.zero;
    private Vector2 lastPosition = Vector2.zero;
    
    private void Start()
    {
        startTime = Time.fixedTime;
        startPosition = transform.position;
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (Time.time - startTime > lifetime)
        {
            Destroy(gameObject);
            return;
        }
        
        float timeDiff = Time.fixedTime - startTime;
        float yComp = (float)Math.Sin(timeDiff*frequency)*amplitude;
        Vector2 v = new Vector2(timeDiff*frequency, yComp);
        
        rb.MovePosition(startPosition + v.Rotated(angle).ToVector3());

        currentDirection = transform.position.ToVector2() - lastPosition;
        lastPosition = transform.position.ToVector2();
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject == Manager.Instance.player) {
            Health playerHealth = collider2D.gameObject.GetComponent<Health>();
            Movement playerMovement = collider2D.gameObject.GetComponent<Movement>();
            Assert.IsNotNull(playerHealth, "Player doesn't have a Health component");
            Assert.IsNotNull(playerMovement, "Player doesn't have a Movement component");
				
            playerHealth.TakeDamage(damage);
            playerMovement.Impulse(currentDirection.normalized * knockbackAmount);
            Manager.Instance.PlaySound(hitSound);
            Destroy(gameObject);
        }
			
        if (collider2D.gameObject.layer == 8) {
            Destroy(gameObject);
        }
    }
}
