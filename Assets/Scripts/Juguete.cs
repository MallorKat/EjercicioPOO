using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juguete : MonoBehaviour, IDaño
{
    [SerializeField]
    private int _resistencia;

    [SerializeField]
    private Rigidbody _RbJuguete;

    void Start()
    {
        _RbJuguete = GetComponent<Rigidbody>();
    }
    public void HacerDaño(int daño)
    {
        _resistencia -= daño;
        SalirDisparado();
        Debug.Log("Golpeando");
        if (_resistencia <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Se rompió!!!");
        }
    }
    void SalirDisparado()
    {
        _RbJuguete.AddForce(Vector3.up * 3, ForceMode.Impulse);
        _RbJuguete.AddForce(Vector3.forward * 5, ForceMode.Impulse);
    }
}
