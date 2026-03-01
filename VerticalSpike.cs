using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSpike : MonoBehaviour
{
    public float velocidad = 1f;    // Qué tan rápido se mueve
    public float altura = 1f;       // Qué tan alto sube
    private float posicionInicialY; // Guarda la posición base

    void Start()
    {
        posicionInicialY = transform.position.y;
    }

    void Update()
    {
        float nuevaY = posicionInicialY + Mathf.PingPong(Time.time * velocidad, altura);
        transform.position = new Vector3(transform.position.x, nuevaY, transform.position.z);
    }
}
