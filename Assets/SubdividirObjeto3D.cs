using UnityEngine;

public class SubdividirObjeto3D : MonoBehaviour
{
    public GameObject partePrefab; // Prefab de la parte en la que se dividir� el objeto.
    public float fuerzaExplosion = 5f; // Fuerza de la explosi�n cuando se divide.
    public int cantidadMinimaPartes = 2; // Cantidad m�nima de partes.
    public int cantidadMaximaPartes = 5; // Cantidad m�xima de partes.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Subdividir();
        }
    }

    private void Subdividir()
    {
        // Generar una cantidad aleatoria de partes
        int cantidadPartes = Random.Range(cantidadMinimaPartes, cantidadMaximaPartes + 1);

        for (int i = 0; i < cantidadPartes; i++)
        {
            GameObject nuevaParte = Instantiate(partePrefab, transform.position, Quaternion.identity);
            Rigidbody rbParte = nuevaParte.GetComponent<Rigidbody>();

            // Aplicar una fuerza aleatoria a cada parte
            Vector3 direccionFuerza = Random.insideUnitSphere.normalized;
            rbParte.AddForce(direccionFuerza * fuerzaExplosion, ForceMode.Impulse);

            // Agregar gravedad a cada parte
            rbParte.useGravity = true;
        }

        // Destruir el objeto original
        Destroy(gameObject);
    }
}
