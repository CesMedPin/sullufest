using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPEscena2 : MonoBehaviour
{
    public string siguienteEscena = "Level2";
    public float tiempoEspera = 5f;
    public Animator banderaAnimator; // ASIGNAR en el Inspector
    public string triggerName = "Activar";

    private bool activado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activado && collision.CompareTag("Player"))
        {
            activado = true;

            var respawn = collision.GetComponent<PlayerRespawn>();
            if (respawn != null)
                respawn.ReachedCheckPoint(transform.position.x, transform.position.y);

            // Si el Animator está en un GameObject inactivo, lo activamos
            if (banderaAnimator != null)
            {
                if (!banderaAnimator.gameObject.activeInHierarchy)
                    banderaAnimator.gameObject.SetActive(true);

                // Si el componente Animator está deshabilitado, lo habilitamos
                if (!banderaAnimator.enabled)
                    banderaAnimator.enabled = true;

                // Usar trigger (asegúrate que exista en el Animator)
                banderaAnimator.SetTrigger(triggerName);

                // Alternativa: reproducir directamente un estado por nombre
                // banderaAnimator.Play("NombreDelEstado");
            }
            else
            {
                Debug.LogWarning("BanderaAnimator no asignado en CheckPoint.");
            }

            StartCoroutine(CambiarEscenaDespuesDeTiempo());
        }
    }

    private System.Collections.IEnumerator CambiarEscenaDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene(siguienteEscena);
    }
}
