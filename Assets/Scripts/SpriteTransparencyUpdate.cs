using UnityEngine;

public class SpriteTransparencyUpdate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    void FixedUpdate()
    {
        if ((Manager.Instance.player.transform.position.y - transform.position.y) > 0)
        {
            spriteRenderer.material = Manager.Instance.TransparencySpriteMaterial;
        }
        else
        {
            spriteRenderer.material = Manager.Instance.RegularSpriteMaterial;
        }
    }
}
