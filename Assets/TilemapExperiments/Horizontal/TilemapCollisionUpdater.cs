using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollisionUpdater : MonoBehaviour
{
    [SerializeReference] private List<TilemapCollider2D> tilemaps;
    private TilemapCollider2D lastTilemapCollider;
    void Update()
    {
        int height = -(transform.position.z > 0 ? (int)transform.position.z : (int)transform.position.z - 1) - 1;
        if (lastTilemapCollider !=null)
            lastTilemapCollider.enabled = false;
        lastTilemapCollider = tilemaps[height+5];
        lastTilemapCollider.enabled=true;
    }
}
