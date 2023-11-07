using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huron : MonoBehaviour
{
    protected ControlJuego controlJuego;

    [SerializeField]
    protected string _nombre;

    [SerializeField]
    protected float giro;
    [SerializeField]
    protected float fuerzaSalto;

    [SerializeField]
    protected float Velocidad;

    [SerializeField]
    protected Rigidbody rbPochito;

    protected float horizontalInput;
    protected float forwardInput;

    protected bool huronEnSuelo = true;

    [SerializeField]
    protected int _dañoGolpe;

    // ENCAPSULATION
    [SerializeField]
    protected string _raza;
    private List<string> _razasValidas = new List<string>() { "Sable", "Canela", "Albina", "Champan" };
    public string GetRaza()
    {
        return _raza;
    }
    public void SetRaza(string raza)
    {
        if (_razasValidas.Contains(raza))
        {
            _raza = raza;
            controlJuego.avisoNoTipo.text = "";
        }
        else
        {
            Debug.Log("Raza no valida para hurones");
            controlJuego.avisoNoTipo.text = "No existe este tipo de hurón.";
        }
    }
    //ENCAPSULATION

    void Start()
    {
        controlJuego = GameObject.Find("ControlJuego").GetComponent<ControlJuego>();
        rbPochito = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ABSTRACTION
        Movimiento();
        if (Input.GetKeyDown(KeyCode.Space) && huronEnSuelo)
        {
            // ABSTRACTION
            Salto();
            huronEnSuelo = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && huronEnSuelo)
        {
            // ABSTRACTION
            Salto();
            AtaqueAereo();
            huronEnSuelo = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // ABSTRACTION
            AtaqueEspecial();
        }
    }

    // ABSTRACTION
    void Movimiento()
    {
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Velocidad * forwardInput * Time.deltaTime);
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * giro * horizontalInput * Time.deltaTime);
    }
    void Salto()
    {
        rbPochito.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }
    void AtaqueAereo()
    {
        rbPochito.AddTorque(0, 80, 0, ForceMode.Impulse);
    }
    protected virtual void AtaqueEspecial()
    {
        Debug.Log("Cada hurón tendrá su ataque diferenciado pero con la misma tecla");
    }
    // ABSTRACCION.

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            huronEnSuelo = true;
        }

        IDaño objeto = other.gameObject.GetComponent<IDaño>();

        if (other.gameObject.GetComponent<IDaño>() != null)
        {
            objeto.HacerDaño(_dañoGolpe);
        }
    }
}
