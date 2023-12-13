using UnityEngine;

public class ActivarAnimacionEnColision : MonoBehaviour
{
    public Animation anim; // Asigna el componente Animation del objeto FBX en el Inspector.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Cambia "Player" al tag del objeto que debe activar la animaci�n.
        {
            if (!anim.isPlaying) // Verifica si la animaci�n no se est� reproduciendo actualmente para evitar reiniciarla si ya est� en curso.
            {
                anim.Play("Take 001"); // Reemplaza "NombreDeLaAnimacion" con el nombre de tu animaci�n.
            }
        }
    }
}