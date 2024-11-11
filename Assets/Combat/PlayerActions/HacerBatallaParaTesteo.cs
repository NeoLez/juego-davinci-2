using System.Collections;
using System.Collections.Generic;
using Combat;
using Combat.Controllers;
using UnityEngine;

public class HacerBatallaParaTesteo : MonoBehaviour
{
    public CombatManager CombatManager;
    public VisualsManager VisualsManager;
    public GameObject canvas;
    void Start() {
        Fighter enemyFighter = new Fighter(Resources.Load<CharacterDataSO>("CharacterInfo/Basic"));
        Fighter playerFighter = new Fighter(Resources.Load<CharacterDataSO>("CharacterInfo/Player"));
        
        enemyFighter.SetController(new BasicAttackController(enemyFighter));
        PlayerController playerController = canvas.GetComponent<PlayerController>();
        playerFighter.SetController(playerController);


        CombatManager = new CombatManager(playerFighter, enemyFighter, true);
        VisualsManager = new VisualsManager(playerFighter, enemyFighter);
    }
    //INTERFAZ
    //MEJORAR FORMA DE INTERACTUAR CON LAS STATS
    //Forma de obtener lista de habilidades
    //Efectos
    //SCENE CHANGE
}
