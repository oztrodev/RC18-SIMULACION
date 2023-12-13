using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarEscena : MonoBehaviour
{
    // Define el nombre de la escena actual (puedes obtenerlo automáticamente si lo prefieres)
    public string nombreDeLaEscena;

    // Llama a esta función cuando el botón sea presionado
    public void Reiniciar()
    {
        // Si no se proporciona un nombre de escena, obtén el nombre de la escena actual
        if (string.IsNullOrEmpty(nombreDeLaEscena))
        {
            nombreDeLaEscena = SceneManager.GetActiveScene().name;
        }

        // Carga la escena actual para reiniciarla
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
