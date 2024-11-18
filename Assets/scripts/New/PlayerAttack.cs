using System;
using System.Collections;
using System.Collections.Generic;
using New;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Movement playerMovement;
    [SerializeField] private Vector2 attackSize;
    [SerializeField] private int damage;
    [SerializeField] private float knockbackIntensity;
    [SerializeField] private float attackCooldown;
    [SerializeField] private AudioClip hitAudio;
    private Timer attackTimer;

    public event Action OnPlayerAttack;

    private void Start() {
        attackTimer = new Timer(Timer.UpdateType.UPDATE);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && !attackTimer.IsWaiting()) {
            attackTimer.Wait(attackCooldown);
            OnPlayerAttack?.Invoke();
            
            Vector2 lookDirection = playerMovement.GetLastMoveVector();
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position.ToVector2() + lookDirection * attackSize.x/2, attackSize, Mathf.Rad2Deg * (float)lookDirection.GetAngle());
            
            foreach (Collider2D hit in hits) {
                if (hit.gameObject!=gameObject && hit.gameObject.TryGetComponent(out Health life))
                {
                    life.TakeDamage(damage);
                    if (hit.gameObject.TryGetComponent(out Movement movement)) {
                        movement.Impulse(lookDirection * knockbackIntensity);
                    }
                    if (hit.gameObject.TryGetComponent(out EnemyDetection detection)) {
                        detection.SetBehaviourState(EnemyDetection.BehaviourState.CHASING);
                    }
                    
                    Manager.Instance.PlaySound(hitAudio, 1);
                }
            }
        }
    }
}
