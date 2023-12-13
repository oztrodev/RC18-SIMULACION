using UnityEngine;

public class ActivarGameObject : MonoBehaviour
{
    // Declaración de variables públicas para los ocho Game Objects
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;
    public GameObject objeto4;
    public GameObject objeto5;
    public GameObject objeto6;
    public GameObject objeto7;
    public GameObject objeto8;

    // Declaración del GameObject que se activará cuando los ocho estén activos
    public GameObject objetoAActivar;

    private void Update()
    {
        // Verificar si los ocho Game Objects están activos
        if (objeto1.activeSelf && objeto2.activeSelf && objeto3.activeSelf &&
            objeto4.activeSelf && objeto5.activeSelf && objeto6.activeSelf &&
            objeto7.activeSelf && objeto8.activeSelf)
        {
            // Activa el objeto deseado
            objetoAActivar.SetActive(true);
        }
    }
}
