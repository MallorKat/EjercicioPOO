using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    [SerializeField]
    private GameObject Milky;
    [SerializeField]
    private GameObject Trasto;
    [SerializeField]
    private GameObject Popi;

    public Text textoHuron;
    public Text textoGetSet;
    public Text textoJugador;
    public Text ataqueEspecial;
    public Text avisoNoTipo;

    private Huron miHuron;

    // Start is called before the first frame update
    void Start()
    {
        textoJugador.text = DatosJuego.Instance.nombreJugador;

        if (DatosJuego.Instance.pochi == 1)
        {
            Trasto.SetActive(true);
            miHuron = GameObject.Find("Trasto").GetComponent<Trasto>();
            textoHuron.text = "Trasto";
        }
        if (DatosJuego.Instance.pochi == 2)
        {
            Popi.SetActive(true);
            miHuron = GameObject.Find("Popi").GetComponent<Popi>();
            textoHuron.text = "Popita";
        }
        if (DatosJuego.Instance.pochi == 3)
        {
            Milky.SetActive(true);
            miHuron = GameObject.Find("Milky").GetComponent<Milky>();
            textoHuron.text = "MilkyWay";
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            miHuron.SetRaza("Sable");
            ImprimirTipo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            miHuron.SetRaza("Canela");
            ImprimirTipo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            miHuron.SetRaza("Albina");
            ImprimirTipo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            miHuron.SetRaza("Champan");
            ImprimirTipo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            miHuron.SetRaza("Popchita");
            ImprimirTipo();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(0);
        }
    }
    void ImprimirTipo()
    {
        print("mi Huron es: " + miHuron.GetRaza());
        textoGetSet.text = "Tengo un hurón " + miHuron.GetRaza();
    }
}
