using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using New;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver; // Referencia al menu de Game Over
    private Health health; // Referencia al script CombateJugador

    private void Start()
    {
        // Busca al jugador por su tag y obtiene el componente CombateJugador
        health = Manager.Instance.player.GetComponent<Health>(); ;

        // Suscribe el metodo ActivarMenu al evento MuerteJugador
        health.OnDeathEvent += ActivarMenu;
    }

    // Metodo que se activa cuando el jugador muere
    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true); // Activa el menu de Game Over
        Time.timeScale = 0;
    }

    // Metodo para reiniciar el nivel actual
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Metodo para cargar el menu inicial
    public void MenuInicial(string nombre)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre);
    }
}
