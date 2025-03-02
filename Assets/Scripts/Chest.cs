using System.Collections;
using System.Collections.Generic;
using New;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject monedaPrefab;
    public int cantidadMonedas = 1;
    public Sprite spriteCerrado, spriteAbierto;
    private SpriteRenderer spriteRenderer;

    public KeyCode teclaParaAbrir = KeyCode.E;
    private bool estaAbierto = false;
    private bool jugadorCerca = false;

    [Header("Configuración de Llave")]
    public bool requiereLlave = false;
    public string llaveNecesaria = "LlaveCofre";

    [Header("Sonidos")]
    public AudioClip sonidoCerrado; 
    public AudioClip sonidoAbierto;
    public List<AudioClip> coinDropSounds;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && spriteCerrado != null)
        {
            spriteRenderer.sprite = spriteCerrado;
        }
    }

    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(teclaParaAbrir))
        {
            IntentarAbrirCofre();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }

    void IntentarAbrirCofre()
    {
        if (estaAbierto) return;

        if (requiereLlave && !GameManager.Instance.TieneLlave(llaveNecesaria))
        {
            GameManager.Instance.ReproducirSonido(sonidoCerrado);
            return;
        }

        StartCoroutine(AbrirCofre());
    }

    IEnumerator AbrirCofre()
    {
        estaAbierto = true;

        if (spriteRenderer != null && spriteAbierto != null)
        {
            spriteRenderer.sprite = spriteAbierto;
        }

        
        GameManager.Instance.ReproducirSonido(sonidoAbierto);

        if (requiereLlave)
        {
            GameManager.Instance.UsarLlave(llaveNecesaria);
        }

        
        if (monedaPrefab != null)
        {
            for (int i = 0; i < cantidadMonedas; i++)
            {
                Vector3 posicionMoneda = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.3f, 0.7f), -0);
                GameObject coin = Instantiate(monedaPrefab, posicionMoneda, Quaternion.identity);
                Vector2 impulse = new Vector2(Random.Range(-2f, 2f), Random.Range(1.0f, 4.0f));
				coin.GetComponent<Movement>().Impulse(impulse * 3);
                GameManager.Instance.ReproducirSonido(coinDropSounds[Mathf.FloorToInt(Random.Range(0,coinDropSounds.Count))]);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
