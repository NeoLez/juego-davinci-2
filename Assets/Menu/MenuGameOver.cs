using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject menuGameOver; 
    private Health health; 

    private void Start()
    {
        
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        
        health.OnDeathEvent += ActivarMenu;
    }

    
    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true); 
    }

    
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
