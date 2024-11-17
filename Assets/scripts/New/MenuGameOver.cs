using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using New;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver; // Referencia al men� de Game Over
    private Health health; // Referencia al script CombateJugador

    private void Start()
    {
        // Busca al jugador por su tag y obtiene el componente CombateJugador
        health = Manager.Instance.player.GetComponent<Health>(); ;

        // Suscribe el m�todo ActivarMenu al evento MuerteJugador
        health.OnDeathEvent += ActivarMenu;
    }

    // M�todo que se activa cuando el jugador muere
    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true); // Activa el men� de Game Over
    }

    // M�todo para reiniciar el nivel actual
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // M�todo para cargar el men� inicial
    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
