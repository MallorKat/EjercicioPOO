using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juguete : MonoBehaviour, IDa�o
{
    [SerializeField]
    private int _resistencia;

    [SerializeField]
    private Rigidbody _RbJuguete;

    void Start()
    {
        _RbJuguete = GetComponent<Rigidbody>();
    }
    public void HacerDa�o(int da�o)
    {
        _resistencia -= da�o;
        SalirDisparado();
        Debug.Log("Golpeando");
        if (_resistencia <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Se rompi�!!!");
        }
    }
    void SalirDisparado()
    {
        _RbJuguete.AddForce(Vector3.up * 3, ForceMode.Impulse);
        _RbJuguete.AddForce(Vector3.forward * 5, ForceMode.Impulse);
    }
}
