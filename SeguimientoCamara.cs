using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform target;  // El personaje a seguir
    public float smoothSpeed = 0.125f; // Qué tan suave sigue la cámara
    public Vector3 offset = new Vector3(1f, 0.65f, 0f);    // Separación opcional de la cámara respecto al personaje

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
