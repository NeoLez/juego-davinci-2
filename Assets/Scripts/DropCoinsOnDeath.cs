using System;
using New;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropCoinsOnDeath : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Health health;
    [SerializeField] private int coinAmountMax;
    [SerializeField] private int coinAmountMin;
    [SerializeField] private float chanceToDrop;

    private void Start() {
        health.OnDeathEvent += DropKey;
    }

    private void DropKey() {
        if (Random.Range(0.0f, 1.0f) <= chanceToDrop)
        {
            int coinAmount = Random.Range(coinAmountMin, coinAmountMax+1);
            for (int i = 0; i < coinAmount; i++)
            {
                GameObject coin = Instantiate(coinPrefab);
                coin.transform.position = transform.position;
                coin.GetComponent<Movement>().Impulse(Random.insideUnitCircle * 7);
            }
        }
    }
}
