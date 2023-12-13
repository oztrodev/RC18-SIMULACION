using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoContador : MonoBehaviour
{
    public AudioClip sonido; // El sonido que se emitirá al alcanzar 5 colisiones.
    private int contador = 0; // Contador de colisiones.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Comprueba si el objeto que colisiona es el jugador.
        {
            contador++; // Incrementa el contador de colisiones.

            if (contador == 5) // Si el contador llega a 5, reproduce el sonido.
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null && sonido != null)
                {
                    audioSource.clip = sonido;
                    audioSource.Play();
                }
            }
        }
    }
}
