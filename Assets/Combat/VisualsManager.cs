using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsManager
{
    public Fighter playerFighter;
    public Fighter enemyFighter;

    public GameObject playerFighterGameObject;
    public GameObject enemyFighterGameObject;

    public SpriteRenderer playerFighterSpriteRenderer;
    public SpriteRenderer enemyFighterSpriteRenderer;


    public VisualsManager(Fighter playerFighter, Fighter enemyFighter)
    {
        this.playerFighter = playerFighter;
        this.enemyFighter = enemyFighter;


        playerFighterGameObject = new GameObject("PlayerFighter");
        enemyFighterGameObject = new GameObject("EnemyFighter");

        playerFighterSpriteRenderer = playerFighterGameObject.AddComponent<SpriteRenderer>();
        enemyFighterSpriteRenderer = enemyFighterGameObject.AddComponent<SpriteRenderer>();
        playerFighterSpriteRenderer.sprite = playerFighter.characterData.Sprite;
        enemyFighterSpriteRenderer.sprite = enemyFighter.characterData.Sprite;

        playerFighterGameObject.transform.position = new Vector3(-5, 0, 0);
        enemyFighterGameObject.transform.position = new Vector3(5, 0, 0);
    }
}
