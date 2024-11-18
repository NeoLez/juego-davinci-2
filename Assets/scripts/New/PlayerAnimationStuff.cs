using System;
using System.Collections;
using System.Collections.Generic;
using New;
using UnityEngine;

public class PlayerAnimationStuff : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Movement movement;
    [SerializeField] private PlayerAttack playerAttack;

    private void Start() {
        playerAttack.OnPlayerAttack += () => {
            playerAnimator.SetTrigger("Attack");
        };
    }

    void Update() {
        Vector2 moveVector = movement.GetDirectionVector();
        Vector2 lastMoveVector = movement.GetLastMoveVector();
        
        playerAnimator.SetFloat("Horizontal", moveVector.x);
        playerAnimator.SetFloat("Vertical", moveVector.y);
        playerAnimator.SetFloat("Speed", moveVector.magnitude);
        playerAnimator.SetFloat("LastHorizontal", lastMoveVector.x);
        playerAnimator.SetFloat("LastVertical", lastMoveVector.y);
    }
}
