using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public string userEmail;
    public string idUser;
    public int idHito;
    public string hito;

    public int conseguido;

    public InputField InputEmail;
    public InputField InputPassword;

    public Button btnLogin;

    public UnityEvent loginSuccessEvent;

    public GameObject loginPanel;
    public GameObject mainPanel;

    
    public Toggle checkHito2;

    public Toggle checkHitoTerrenoMojadobien;
    public Toggle checkHitoPisoIrregularbien;
    public Toggle checkHitoCenefabien;
    public Toggle checkHitoDragerbien;
    public Toggle checkHitoIluminacionbien;
    // public Toggle checkHito5mal;

    /// <summary>
    /// Hito3
    /// </summary>
    public Toggle checkHito3;

    /// <summary>
    /// Hito5
    /// </summary>
    public Toggle checkHito5;

    /// <summary>
    /// Hito7
    /// </summary>
    public Toggle checkHito7;

    /// <summary>
    /// Hito8
    /// </summary>
    public Toggle checkHito8;

    /// <summary>
    /// Hito9
    /// </summary>
    public Toggle checkHito9;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


public void IntentarLoginYCrearUsuario(string email, string password)
{
    // Intenta iniciar sesión con el email y contraseña proporcionados
    WebServices.instance.IniciarSesion(email, password, (loginExitoso) =>
    {
        if (loginExitoso)
        {
            Debug.Log("Inicio de sesión exitoso.");
            // Aquí podrías continuar con el flujo después de un inicio de sesión exitoso
        }
        else
        {
            Debug.Log("Inicio de sesión fallido, intentando crear usuario.");
            // El inicio de sesión ha fallado, intenta crear un nuevo usuario
            WebServices.instance.CrearUsuario(email, password, (usuarioCreado) =>
            {
                if (usuarioCreado)
                {
                    Debug.Log("Usuario creado exitosamente.");
                    // Continuar con el flujo después de crear el usuario
                }
                else
                {
                    Debug.LogError("No se pudo crear el usuario.");
                    // Manejar el error de creación de usuario
                }
            });
        }
    });
}


    public static bool EsEmailValido(string email)
    {
    // Patrón simple para validar un email
        string patronEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        return Regex.IsMatch(email, patronEmail);
    }

    public void Login()
    {
        Debug.Log(InputEmail.text);
        string email = InputEmail.text;
        string password = InputPassword.text;
        Debug.Log("LOOOOGIIIIIIIIIIINNNNNNNNNNNNNNN No se pudo crear el usuario.");

        if (!EsEmailValido(email))
            {
                Debug.LogError("El correo electrónico no es válido.");
                return; // Detiene la ejecución si el email no es válido
            }

        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
        {

            IntentarLoginYCrearUsuario(email, password);
            // WebServices.instance.CrearUsuario(email, password, (usuarioCreado) =>
            // {
            //     if (usuarioCreado)
            //     {
            //         Debug.Log("Usuario creado exitosamente.");
            //         // Continuar con el flujo después de crear el usuario
            //     }
            //     else
            //     {
            //         Debug.LogError("No se pudo crear el usuario.");
            //         // Manejar el error de creación de usuario
            //     }
            // });
        }
        else
        {
            Debug.LogError("El nombre de usuario y la contraseña no pueden estar vacíos.");
        }
    }


    public void AddToPuntaje(int puntosToAdd)
    {
        // Obtener el puntaje actual, si no existe, el valor predeterminado será 0
        int puntajeActual = PlayerPrefs.GetInt("puntaje", 0);

        // Sumar los puntos al puntaje actual
        puntajeActual += puntosToAdd;

        // Guardar el nuevo puntaje
        PlayerPrefs.SetInt("puntaje", puntajeActual);

        // Es buena práctica guardar después de modificar los PlayerPrefs
        PlayerPrefs.Save();
    }


    public void LoginSuccess(string username)
    {

   
        PlayerPrefs.SetString("username", username);
        // PlayerPrefs.SetString("idUser", username);
        PlayerPrefs.Save();

        loginSuccessEvent.Invoke();
        if(loginPanel)
            loginPanel.SetActive(false);
        // loginPanel.SetActive(false);
        // mainPanel.SetActive(true);
        // Debug.LogError("ACTIVACION DE TUNEL.");
        // SceneManager.LoadScene("TUNEL_NUEVO");
        // SceneManager.LoadScene("UI_MARCOLEGAL");
    }

    // public void SendHito2()
    // {
    //     string idUser = PlayerPrefs.GetString("idUser", string.Empty);
    //     idHito=2;
    //     int conseguido = 1;
    //     WebServices.instance.SendHito(idUser, idHito, conseguido);
    // }

    public void SendHito2()
    {   
        // "MARCO LEGAL"
        if (checkHito2.isOn){
            conseguido = 1;
        }
        else
            conseguido = 0;

        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento");

       
        if (!string.IsNullOrEmpty(idUser))
        {
            idHito=2;
            hito="MARCO LEGAL";
            AddToPuntaje(conseguido);
            WebServices.instance.SendHito(idUser, idHito, conseguido,hito,intento);
        }
        else
        {
            Debug.LogError("No username found in PlayerPrefs.");
        }
    }

    public void SendHito3()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=3;
        conseguido = 1;
        hito = "OBJETIVOS";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido,hito,intento);
    }

    public void SendHito4()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=4;
        conseguido = 1;
        hito = "EPP VERIFICADO";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito,intento);
    }

    public void SendHito5()
    {

        Debug.Log("TERRENO MOJADO");
        if (checkHitoTerrenoMojadobien.isOn){
            conseguido = 1;
        }
        else{
            conseguido = 0;
        }
        
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=5;
        hito = "TERRENO MOJADO";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento);
    }

    public void SendHito6()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=6;
        conseguido = 1;
        hito = "INSTALACION BOMBA";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento);
    }

    public void SendHito7()
    {
        if (checkHitoPisoIrregularbien.isOn){
            conseguido = 1;
        }
        else{
            conseguido = 0;
        }
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=7;
        hito = "PISO IRREGULAR";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento);
    }

    public void SendHito8()
    {

        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=8;
        conseguido = 1;
        hito = "CUADRILLA LIMPIA";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito,intento);
    }
    public void SendHito9()
    {
        if (checkHitoCenefabien.isOn)
        {
            conseguido = 1;
        }
        else
        {
            conseguido = 0;
        }

        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=9;
        hito = "CENEFA";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito,intento);
    }
    public void SendHito10()
    {
        if (checkHitoDragerbien.isOn)
            conseguido = 1;
        else
            conseguido = 0;

        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=10;
        hito = "DRAGER";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito,intento);
    }
    public void SendHito11()
    {
        if (checkHitoIluminacionbien.isOn)
            conseguido = 1;
        else
            conseguido = 0;
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=11;
        hito = "ILUMINACION";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito,intento);
    }
    public void SendHito12()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=12;
        conseguido = 1;
        hito = "TIPS VERIFICADOS";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento);
    }
    public void SendHito13()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=13;
        conseguido = 1;
        hito = "ILUMINACION";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento);
    }
    public void SendHito14()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=14;
        conseguido = 1;
        hito = "TIPS VERIFICADOS";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento);
    }
    public void SendHito15()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=15;
        conseguido = 1;
        hito = "INGRESO SIMULACION";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento);
    }
    public void SendHito16()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        idHito=16;
        conseguido = 1;
        hito = "BARRETILLA";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento);
    }
    public void SendHito17()
    {
        string idUser = PlayerPrefs.GetString("idUser", string.Empty);
        int intento = PlayerPrefs.GetInt("intento", 0);
        
        idHito=17;
        conseguido = 1;
        hito = "SIMULACION";
        AddToPuntaje(conseguido);
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito,intento);
    }
    public void SendHito18()
    {
        string  idUser   = PlayerPrefs.GetString("idUser", string.Empty);
        string  idCurso  = PlayerPrefs.GetString("idCurso", string.Empty);
        string  curso    = PlayerPrefs.GetString("curso", string.Empty);
        string  inicio   = PlayerPrefs.GetString("inicio", string.Empty);
        int     intento = PlayerPrefs.GetInt("intento", 0);
        int     puntaje  = PlayerPrefs.GetInt("puntaje", 0);
        string  email    = PlayerPrefs.GetString("email", string.Empty);
        PlayerPrefs.SetString("termino", DateTime.Now.ToString("o")); 
        PlayerPrefs.Save();
        string  termino   = PlayerPrefs.GetString("termino", string.Empty);
        Debug.LogError("termino: " + termino);
        Debug.LogError("inicio: " + inicio);



        Debug.LogError("PUNTAJE: " + puntaje);
        idHito=18;
        hito = "TERMINO";
        WebServices.instance.SendHito(idUser, idHito, conseguido, hito, intento=0);
        WebServices.instance.SendGraduado(idUser,email, idCurso, curso, intento, puntaje, inicio, termino);
        // WebServices.instance.SendGraduado(idUser, idHito, conseguido, hito, intentos);
        Quit();

    }
    

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
