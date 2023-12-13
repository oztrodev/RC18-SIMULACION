using UnityEngine;

public class ActivarAnimacionEnColision : MonoBehaviour
{
    public Animation anim; // Asigna el componente Animation del objeto FBX en el Inspector.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Cambia "Player" al tag del objeto que debe activar la animación.
        {
            if (!anim.isPlaying) // Verifica si la animación no se está reproduciendo actualmente para evitar reiniciarla si ya está en curso.
            {
                anim.Play("Take 001"); // Reemplaza "NombreDeLaAnimacion" con el nombre de tu animación.
            }
        }
    }
}