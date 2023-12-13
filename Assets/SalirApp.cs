using UnityEngine;

public class SalirApp : MonoBehaviour
{
    // Este método se asociará al evento de clic del botón en Unity
    public void SalirDeLaAplicacion()
    {
        // Verifica si la aplicación no está en el editor de Unity
        if (!Application.isEditor)
        {
            // Sale de la aplicación
            Application.Quit();
        }
        else
        {
            // En el editor, simplemente detiene la reproducción
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}

