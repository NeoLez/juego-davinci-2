using System;
using New;
using UnityEngine;
using UnityEngine.UI;

public class InterfazVida : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int maxHealthPoints;

    private Health health;

    private void Start() {
        health = Manager.Instance.player.GetComponent<Health>();
    }

    private void Update() {
        slider.value = health.GetHealth() / (float) maxHealthPoints;
    }
}
