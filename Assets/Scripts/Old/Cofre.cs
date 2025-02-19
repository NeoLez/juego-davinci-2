using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
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
            Debug.Log("Presiona 'F' para abrir el cofre.");
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
            Debug.Log("Necesitas la llave para abrir este cofre.");

            
            GameManager.Instance.ReproducirSonido(sonidoCerrado);
            return;
        }

        AbrirCofre();
    }

    void AbrirCofre()
    {
        estaAbierto = true;
        Debug.Log("¡El cofre se ha abierto!");

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
                Vector3 posicionMoneda = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.3f, 0.7f), 0);
                Instantiate(monedaPrefab, posicionMoneda, Quaternion.identity);
            }
        }
    }
}
