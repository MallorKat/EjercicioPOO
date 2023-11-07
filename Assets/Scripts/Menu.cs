using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private DatosJuego datosJuego;

    [SerializeField]
    private bool hayNombre;

    void Start()
    {
        // Esto hace que el cursor vuelva a aparecer.
        Cursor.lockState = CursorLockMode.None;
    }

    public void IntroducirNombreJugador(string jugador)
    {
        DatosJuego.Instance.nombreJugador = jugador;
        hayNombre = true;
    }

   public void Jugar(int pochi)
    {
        if (hayNombre == true)
        {
            DatosJuego.Instance.pochi = pochi;
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("No hay nombre de jugador");
        }
    }
}
