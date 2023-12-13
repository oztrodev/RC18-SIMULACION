using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public int collisionCountToTrigger = 5;
    private int currentCollisionCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador colisiona con el objeto
        if (collision.gameObject.CompareTag("Player"))
        {
            currentCollisionCount++;

            // Verificar si se alcanz� el n�mero de colisiones deseado
            if (currentCollisionCount >= collisionCountToTrigger)
            {
                // Reproducir el audio cuando se alcanza la quinta colisi�n
                audioSource.Play();
                currentCollisionCount = 0; // Reiniciar el contador de colisiones
            }
        }
    }
}
