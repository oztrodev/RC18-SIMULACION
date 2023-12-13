using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]



public class DataGraduado
{
    public string idUser;
    public string email;
    public string idCurso;
    public string curso;
    public int intento;
    public int puntaje;
    public string inicio;
    public string termino;

}

public class UsuarioData
{
    public string username;
    public string password;
    public string email;
    public string idUser;


}

[Serializable]
public class HitoData
{
    public string idUser;
    public int idHito;
    public int conseguido;
    public string hito;
    public int intento;
}

// Esta clase debe coincidir con la estructura de la respuesta JSON que esperas recibir
[Serializable]
public class UserData
{
    public string id;
    // Añade otros campos si son necesarios.
}

[Serializable]
public class AuthResponse
{
    public UserData user;
    // Añade otros campos si son necesarios.
}

[Serializable]
public class ServerResponse
{
    public string message;
    public AuthResponse session; // Modificado para usar AuthResponse
    // Añade otros campos si son necesarios.
}

public class WebServices : MonoBehaviour
{
    public static WebServices instance;

    // public string signUpUrl = "https://plataformacodelcovr.cl/.netlify/functions/nuevoUsuario";
    // public string hitoUrl = "https://plataformacodelcovr.cl/.netlify/functions/nuevoHito";
    public string signUpUrl   = "https://plataformacodelcovr.cl/.netlify/functions/nuevoUsuario";
    public string loginUrl    = "https://plataformacodelcovr.cl/.netlify/functions/iniciarSesion";
    public string hitoUrl     = "https://plataformacodelcovr.cl/.netlify/functions/nuevoHito";
    public string graduadoUrl = "https://plataformacodelcovr.cl/.netlify/functions/nuevoGraduado";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void IniciarSesion(string username, string password, Action<bool> callback)
    {
        Debug.LogError("INICIAR SESION: ");
        // bool resultado = true;
        // signUpUrl = "https://plataformacodelcovr.cl/.netlify/functions/iniciarSesion";
        // signUpUrl = "http://localhost:8888/.netlify/functions/iniciarSesion";
        UsuarioData usuarioData = new UsuarioData
        {
            username = username,
            password = password,
            email = username // Asegúrate de que esto sea un email válido si es necesario
        };

        // StartCoroutine(EnviarDatosAlServidor("https://plataformacodelcovr.cl/.netlify/functions/iniciarSesion", usuarioData, callback));
        StartCoroutine(EnviarDatosAlServidor(loginUrl, usuarioData, callback));

        // StartCoroutine(SimularInicioSesion(username, password, (loginExitoso) =>
        // {
        //     resultado = loginExitoso;
        //     callback?.Invoke(resultado);
        // }));

        // StartCoroutine(EnviarDatosAlServidor(signUpUrl, usuarioData));
    }




    public void CrearUsuario(string username, string password, Action<bool> callback)
    {
        Debug.LogError("CREAR UN NUEVO USUARIO: ");
        // bool resultado = true;
        UsuarioData usuarioData = new UsuarioData
        {
            username = username,
            password = password,
            email = username // Asegúrate de que esto sea un email válido si es necesario
        };
        // StartCoroutine(EnviarDatosAlServidor("https://tubim.cl/.netlify/functions/nuevoUsuario", usuarioData, callback));
        StartCoroutine(EnviarDatosAlServidor(signUpUrl, usuarioData, callback));
        // StartCoroutine(EnviarDatosAlServidor(signUpUrl, usuarioData));

        // StartCoroutine(SimularCreacionUsuario(username, password, (usuarioCreado) =>
        // {
        //     resultado = usuarioCreado;
        //     callback?.Invoke(resultado);
        // }));

    }


    public void SendHito(string idUser, int idHito, int conseguido, string hito, int intento)
    {
        Debug.LogError("ENVIAR HITO: " + intento);
        HitoData hitoData = new HitoData
        {
            idUser = idUser,
            idHito = idHito,
            conseguido = conseguido,
            hito = hito,
            intento = intento
        };
        StartCoroutine(EnviarHitosAlServidor(hitoUrl, hitoData));
    }



    public void SendGraduado(string idUser,string email, string idCurso, string curso, int intento, int puntaje, string inicio, string termino)
    {
        DataGraduado hitoGraduado = new DataGraduado
        {
            idUser   = idUser,
            email    = email,
            idCurso  = idCurso,
            curso    = curso,
            intento  = intento,
            puntaje  = puntaje,
            inicio   = PlayerPrefs.GetString("inicio"),
            termino  = PlayerPrefs.GetString("termino")
        };
        StartCoroutine(EnviarHitosAlServidor(graduadoUrl, hitoGraduado));
    }




    // private IEnumerator SimularCreacionUsuario(string email, string password, Action<bool> callback)
    // {
    //     // Simula una espera de respuesta de red
    //     yield return new WaitForSeconds(2.0f);

    //     // Simula una creación de usuario exitosa
    //     callback?.Invoke(false);
    // }

    // private IEnumerator SimularInicioSesion(string username, string password, Action<bool> callback)
    // {
    //     // Simula una espera de respuesta de red
    //     yield return new WaitForSeconds(2.0f);

    //     // Simula un inicio de sesión exitoso
    //     callback?.Invoke(false);
    // }
    
    private IEnumerator EnviarDatosAlServidor(string url, UsuarioData data, Action<bool> callback)
{
    // Debug.LogError("debvu en la solicitud: ");
    string jsonData = JsonUtility.ToJson(data);
    UnityWebRequest www = UnityWebRequest.Post(url, jsonData);
    www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData));
    www.downloadHandler = new DownloadHandlerBuffer();
    www.SetRequestHeader("Content-Type", "application/json");

    yield return www.SendWebRequest();

    if (www.result != UnityWebRequest.Result.Success)
    {
        // Debug.LogError("Eraaaaror en la solicitud: " + www.error);
        callback(false); // Invocar el callback con 'false' para indicar fallo
    }
    else
    {
        // Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);
        ServerResponse response = JsonUtility.FromJson<ServerResponse>(www.downloadHandler.text);
        
        if (response != null && response.session != null && response.session.user != null)
        {
            Debug.Log("Usuario registrado con éxito. ID: " + response.session.user.id);
            PlayerPrefs.SetString("idUser", response.session.user.id);
            PlayerPrefs.SetString("idCurso", "RC18-SIMULACION");
            PlayerPrefs.SetString("curso", "SIMULACION");
            PlayerPrefs.SetInt("intento", 1);
            PlayerPrefs.SetInt("puntaje", 1);
            PlayerPrefs.SetString("inicio", DateTime.Now.ToString("o")); 
            PlayerPrefs.Save();
            GameManager.instance.LoginSuccess(response.session.user.id);
            callback(true); // Invocar el callback con 'true' para indicar éxito
        }
        else
        {
            Debug.LogError("El registro de usuario falló o la respuesta no contiene los detalles de la sesión.");
            callback(false); // Invocar el callback con 'false' para indicar fallo
        }
    }

    www.Dispose();
}


    private IEnumerator EnviarHitosAlServidor(string url, object data)
    {
        string jsonData = JsonUtility.ToJson(data);
        UnityWebRequest www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
        www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData));
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            // Utiliza www.error para obtener el mensaje de error específico
            Debug.LogError("Error en la conexión o protocolo: " + www.error);
        }
        else
        {
            // La respuesta del servidor fue exitosa
            Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);
            ServerResponse response = JsonUtility.FromJson<ServerResponse>(www.downloadHandler.text);

            if (response != null)
            {
                // La respuesta contiene el objeto esperado
                Debug.Log("HITO INGRESADO: ");
                // Aquí podrías manejar la respuesta más detalladamente, por ejemplo:
                // if (response.message == "some expected message") { ... }
            }
            else
            {
                // La respuesta no contiene el objeto esperado
                Debug.LogError("El registro de usuario falló o la respuesta no contiene los detalles de la sesión.");
            }
        }

        www.Dispose();
    }

}
