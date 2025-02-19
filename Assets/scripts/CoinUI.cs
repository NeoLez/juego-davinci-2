using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI puntos;

    void Update()
    {
        puntos.text = ":" + GameManager.Instance.MonedasRecolectadas.ToString();
    }
}
