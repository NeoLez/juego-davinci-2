using System.Collections;
using System.Collections.Generic;
using Combat;
using Combat.Controllers;
using UnityEngine;

public class HacerBatallaParaTesteo : MonoBehaviour
{
    void Start() {
        
        Fighter enemyFighter = new Fighter(new Stats(3, 2 ,1), "generic_enemy");
        Fighter playerFighter = new Fighter(new Stats(30, 2, 2), "player");
        enemyFighter.SetController(new BasicAttackController(enemyFighter));
        playerFighter.SetController(new PlayerController(playerFighter));
        
        CombatManager c = new CombatManager(playerFighter, enemyFighter, true);
    }
    //MEJORAR FORMA DE INTERACTUAR CON LAS STATS
    //Forma de obtener lista de habilidades
    //Habilidades que carguen //REEMPLAZANDO EL CONTROLADOR???---Deberia estar?
    //Efectos
    //SCENE CHANGE
}
