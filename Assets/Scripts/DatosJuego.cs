using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatosJuego : MonoBehaviour
{
    public static DatosJuego Instance;

    public string nombreJugador;

    public int pochi;

    private void Awake()
    {
        if (DatosJuego.Instance == null)
        {
            DatosJuego.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

