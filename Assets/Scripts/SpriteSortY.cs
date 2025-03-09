using System;
using UnityEngine;
using UnityEngine.Assertions;

public class SpriteSortY : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int offset;

    void Update()
    {
        UpdateOrderInLayer(offset + (int)((Manager.Instance.player.transform.position.y - transform.position.y) * 100));
    }

    public void UpdateOrderInLayer(int orderInLayer)
    {
        spriteRenderer.sortingOrder = orderInLayer;
    }
    
}
