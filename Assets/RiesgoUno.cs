using UnityEngine;
using UnityEngine.SceneManagement;

public class RiesgoUno : MonoBehaviour
{
    public string nombreEscenaDestino; // Nombre de la escena de destino

    public void CambiarASceneDestino()
    {
        SceneManager.LoadScene(nombreEscenaDestino);
    }
}