using UnityEngine;

public class SalirApp : MonoBehaviour
{
    // Este m�todo se asociar� al evento de clic del bot�n en Unity
    public void SalirDeLaAplicacion()
    {
        // Verifica si la aplicaci�n no est� en el editor de Unity
        if (!Application.isEditor)
        {
            // Sale de la aplicaci�n
            Application.Quit();
        }
        else
        {
            // En el editor, simplemente detiene la reproducci�n
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}

