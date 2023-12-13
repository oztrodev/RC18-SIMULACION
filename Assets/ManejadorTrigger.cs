using UnityEngine;

public class ManejadorTrigger : MonoBehaviour
{
    private bool audioReproducido = false;
    public AudioClip audioASReproducir;

    void OnTriggerEnter(Collider otro)
    {
        if (!audioReproducido)
        {
            AudioSource fuenteDeAudio = GetComponent<AudioSource>();
            if (fuenteDeAudio != null && audioASReproducir != null)
            {
                fuenteDeAudio.clip = audioASReproducir;
                fuenteDeAudio.Play();
                audioReproducido = true;
            }
        }
    }
}
