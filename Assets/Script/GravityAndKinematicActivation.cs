using UnityEngine;

public class GravityAndKinematicActivation : MonoBehaviour
{
    private string playerTag = "Player";
    private bool activationDone = false;
    private Rigidbody rb;

    private void Start()
    {
        // Obtenemos el componente Rigidbody del objeto.
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la etiqueta del objeto que colisionó coincide con "Player".
        if (collision.gameObject.CompareTag(playerTag) && !activationDone)
        {
            // Genera un número aleatorio entre 1 y 8.
            int randomActivation = Random.Range(1, 9);

            // Verifica si el número aleatorio coincide con una condición específica.
            if (randomActivation == 1)
            {
                // Activa la gravedad y desactiva kinematic cuando se cumple la condición aleatoria.
                rb.useGravity = true;
                rb.isKinematic = false;

                // Marca la activación como completa para que no se repita.
                activationDone = true;
            }
        }
    }
}
