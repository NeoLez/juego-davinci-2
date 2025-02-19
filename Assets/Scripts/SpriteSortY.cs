using System;
using UnityEngine;
using UnityEngine.Assertions;

public class SpriteSortY : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "No Sprite Renderer to sort");
    }

    void Update()
    {
        spriteRenderer.sortingOrder = (int)((Manager.Instance.player.transform.position.y - transform.position.y) * 100);
    }
}
