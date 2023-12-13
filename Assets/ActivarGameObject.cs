using UnityEngine;

public class ActivarGameObject : MonoBehaviour
{
    // Declaraci�n de variables p�blicas para los ocho Game Objects
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;
    public GameObject objeto4;
    public GameObject objeto5;
    public GameObject objeto6;
    public GameObject objeto7;
    public GameObject objeto8;

    // Declaraci�n del GameObject que se activar� cuando los ocho est�n activos
    public GameObject objetoAActivar;

    private void Update()
    {
        // Verificar si los ocho Game Objects est�n activos
        if (objeto1.activeSelf && objeto2.activeSelf && objeto3.activeSelf &&
            objeto4.activeSelf && objeto5.activeSelf && objeto6.activeSelf &&
            objeto7.activeSelf && objeto8.activeSelf)
        {
            // Activa el objeto deseado
            objetoAActivar.SetActive(true);
        }
    }
}
