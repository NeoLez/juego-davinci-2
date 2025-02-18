using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text ContadorTexto;
    public int Minutos;
    public float Segundos;

    private void Start()
    {
        ActualizarContador();
    }


    void Update()
    {
        Segundos += Time.deltaTime;

        if( Segundos >= 59.5 )
        {
            Segundos = 0;
            Minutos += 1;
        }

        ActualizarContador();
    }

    public void ActualizarContador()
    {
        if (Segundos < 9.5f)
        {
            ContadorTexto.text = Minutos.ToString() + ":0" + Segundos.ToString("f0");
        }
        else 
        { 
            ContadorTexto.text = Minutos.ToString() + ":" + Segundos.ToString("f0");
        }

    }

}

