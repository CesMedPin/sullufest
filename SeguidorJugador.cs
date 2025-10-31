using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorJugador : MonoBehaviour
{
    public Transform objetivo; // El personaje que debe seguir (por ejemplo tu Frog seguirá a "Player")
    public float velocidad = 2f; // Qué tan rápido se mueve
    public float distanciaMinima = 0.5f; // Hasta qué distancia se acercará

    void Update()
    {
        if (objetivo == null) return;

        // Calcula la distancia entre la Frog y el objetivo
        float distancia = Vector2.Distance(transform.position, objetivo.position);

        // Solo se mueve si está más lejos de la distancia mínima
        if (distancia > distanciaMinima)
        {
            // Dirección hacia el objetivo
            Vector2 direccion = (objetivo.position - transform.position).normalized;

            // Movimiento suave hacia el jugador
            transform.position = Vector2.MoveTowards(transform.position,
                                                     objetivo.position,
                                                     velocidad * Time.deltaTime);
        }
    }
}
