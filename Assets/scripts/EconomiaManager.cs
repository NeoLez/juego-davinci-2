using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Monedas")]
    [SerializeField] private int monedasRecolectadas;
    public int MonedasRecolectadas => monedasRecolectadas;

    [Header("Llaves")]
    private HashSet<string> llavesObtenidas = new HashSet<string>(); // Almacena las llaves recolectadas

    [Header("Sonidos")]
    public AudioSource audioSource;
    public AudioClip sonidoMoneda;
    public AudioClip sonidoLlave;
    [Range(0f, 1f)] public float volumenSonidos = 0.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //SUMAR MONEDAS
    public void SumarMoneda(int cantidad)
    {
        monedasRecolectadas += cantidad;
    }

    //SISTEMA DE LLAVES
    public void ObtenerLlave(string llave)
    {
        llavesObtenidas.Add(llave);
        Debug.Log("🔑 Has obtenido la llave: " + llave);

        if (audioSource != null && sonidoLlave != null)
        {
            audioSource.PlayOneShot(sonidoLlave, volumenSonidos);
        }
    }

    public bool TieneLlave(string llave)
    {
        return llavesObtenidas.Contains(llave);
    }

    public void UsarLlave(string llave)
    {
        if (llavesObtenidas.Contains(llave))
        {
            llavesObtenidas.Remove(llave);
            Debug.Log("🗝️ Has usado la llave: " + llave);
        }
    }
    //SONIDOS SIN DILEY
    public void ReproducirSonido(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play(); 
        }
    }
}