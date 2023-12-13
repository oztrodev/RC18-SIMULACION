using UnityEngine;

public class ActivarDesactivarEnTrigger : MonoBehaviour
{
    public GameObject objetoAActivarDesactivar;
    // El GameObject que llevará el trigger debe asignarse desde el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoAActivarDesactivar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoAActivarDesactivar.SetActive(false);
        }
    }
}