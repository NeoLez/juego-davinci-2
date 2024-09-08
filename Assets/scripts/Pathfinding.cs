using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Rigidbody2D rb2D;

    public bool showViewCone = false;
    public bool showViewDetectionSphere = false;
    public bool showSoundDetectionSphere = false;
    [Range(0, 50)]
    public float viewDetectionRadius = 10;
    [Range(0, 2 * Mathf.PI)]
    public float viewDetectionAngle = 60;
    [Range(-Mathf.PI, Mathf.PI)]
    public float viewDetectionAngleOffset = 0;

    [Range(0, 200)]
    public float soundDetectionRadius = 20;

    [Range(3, 100)]
    public int gizmoResolution = 3;

    public bool dothing = false;
    Vector2 targetPosition;
    bool reachedPosition = true;
    float speed = 5;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 playerPos = Manager.player.transform.position;
        if (Vector3.Distance(playerPos, transform.position) < viewDetectionRadius+1)
        {
            if (dothing) {
                //dothing = false;

                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, playerPos - (Vector2)transform.position);
                Array.Sort(hits, (a, b) => (a.distance.CompareTo(b.distance)));

                foreach (RaycastHit2D hit in hits)
                {

                    if (hit.collider.gameObject.layer == 6)
                    {
                        break;
                    }

                    if (hit.collider.gameObject == Manager.player)
                    {
                        //Debug.Log("playerDetected");
                        targetPosition = playerPos;
                        reachedPosition = false;
                        break;
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!reachedPosition)
        {
            Vector2 movement = (targetPosition - (Vector2)transform.position);
            if(movement.magnitude > 0)
                movement.Normalize();

            rb2D.MovePosition((Vector2)transform.position + movement * speed * Time.fixedDeltaTime);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1)
            {
                reachedPosition = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (showViewCone) {
            Vector3[] points = new Vector3[gizmoResolution];
            points[0] = transform.position;
            for (int i = 1; i <= points.Length - 1; i++)
            {
                float angle = (i - 1) * viewDetectionAngle / (gizmoResolution - 2);
                points[i] = transform.position + new Vector3(Mathf.Cos(angle + viewDetectionAngleOffset - viewDetectionAngle / 2), Mathf.Sin(angle + viewDetectionAngleOffset - viewDetectionAngle / 2), 0) * viewDetectionRadius;
            }
            Gizmos.DrawLineStrip(points, true);
        }
        if (showViewDetectionSphere)
        {
            Gizmos.DrawWireSphere(transform.position, viewDetectionRadius);
        }
        if (showSoundDetectionSphere)
        {
            Gizmos.DrawWireSphere(transform.position, soundDetectionRadius);
        }
    }
}
