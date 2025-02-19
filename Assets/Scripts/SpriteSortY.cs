using System;
using UnityEngine;
using UnityEngine.Assertions;

public class SpriteSortY : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update()
    {
        UpdateOrderInLayer((int)((Manager.Instance.player.transform.position.y - transform.position.y) * 100));
    }

    public void UpdateOrderInLayer(int orderInLayer)
    {
        spriteRenderer.sortingOrder = orderInLayer;
    }
    
}
