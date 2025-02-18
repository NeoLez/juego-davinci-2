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
    private bool canBeOpened = false;

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
        if (Input.GetKeyDown(teclaParaAbrir) && canBeOpened)
        {
            AbrirCofre();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canBeOpened = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canBeOpened = false;
        }
    }

    void AbrirCofre()
    {
        if (estaAbierto) return;

        estaAbierto = true;
        Debug.Log("El cofre se ha abierto.");

        
        if (spriteRenderer != null && spriteAbierto != null)
        {
            spriteRenderer.sprite = spriteAbierto;
        }

        
        if (monedaPrefab != null)
        {
            for (int i = 0; i < cantidadMonedas; i++)
            {
                
                Vector3 posicionMoneda = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.3f, 0.7f), 0);
                Instantiate(monedaPrefab, posicionMoneda, Quaternion.identity);
            }
            Debug.Log($"Generadas {cantidadMonedas} monedas.");
        }
    }
}
