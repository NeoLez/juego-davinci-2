using System.Collections;
using System.Collections.Generic;
using New;
using UnityEngine;

public class Berries : MonoBehaviour
{
    private bool isPlayerInRange;
    
    
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F)) {
            Manager.Instance.player.GetComponent<Health>().Heal(1);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Manager.Instance.player == Collision.gameObject)
        {
            isPlayerInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Manager.Instance.player == Collision.gameObject)
        {
            isPlayerInRange = false;
        }
    }
}
