using UnityEngine;

public class CollisionCounter : MonoBehaviour
{
    public GameObject objetoActivar; // El objeto p�blico que quieres activar
    public GameObject objetoDesactivar1; // Primer objeto p�blico que quieres desactivar
    public GameObject objetoDesactivar2; // Segundo objeto p�blico que quieres desactivar
    public GameObject objetoDesactivar3; // Segundo objeto p�blico que quieres desactivar

    private int colisiones = 0;

    // Este m�todo se llama cuando ocurre una colisi�n
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Incrementa el contador de colisiones
            colisiones++;

            // Comprueba si hemos tenido al menos dos colisiones
            if (colisiones >= 2)
            {
                // Activa el objeto p�blico asociado
                objetoActivar.SetActive(true);

                // Desactiva los objetos p�blicos asociados
                if (objetoDesactivar1 != null)
                {
                    objetoDesactivar1.SetActive(false);
                }

                if (objetoDesactivar2 != null)
                {
                    objetoDesactivar2.SetActive(false);
                }

                if (objetoDesactivar3 != null)
                {
                    objetoDesactivar3.SetActive(false);
                }
            }
        }
    }
}
