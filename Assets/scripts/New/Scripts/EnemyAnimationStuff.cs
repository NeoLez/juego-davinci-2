using System.Collections;
using System.Collections.Generic;
using New;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAnimationStuff : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Movement movement;
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private AudioSource audioSource;

    private void Start() {
        enemyAttack.OnEnemyAttack += () => {
            animator.SetTrigger("Attack");
        };
    }

    void Update() {
        Vector2 moveVector = movement.GetDirectionVector();
        Vector2 lastMoveVector = movement.GetLastMoveVector();
        
        animator.SetFloat("Horizontal", moveVector.x);
        animator.SetFloat("Vertical", moveVector.y);
        animator.SetFloat("Speed", moveVector.magnitude);
        animator.SetFloat("LastHorizontal", lastMoveVector.x);
        animator.SetFloat("LastVertical", lastMoveVector.y);
    }

    void PlayFootstepsSound() {
        audioSource.Play();
    }
}
