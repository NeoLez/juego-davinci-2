using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    public int valor = 1;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip audioClip;
    private bool picked;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.9f + Random.Range(0.0f, 0.2f);
        audioSource.volume = 0.4f + Random.Range(0.0f, 0.2f);
        audioSource.clip = audioClip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject collidedObject)
    {
        if (collidedObject.CompareTag("Player") && !picked)
        {
            picked = true;
            spriteRenderer.color = Color.clear;
            GameManager.Instance.SumarMoneda(valor);
            audioSource.Play();
            Destroy(gameObject, audioClip.length+0.5f);
        }
    }
}
