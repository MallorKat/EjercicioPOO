using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Popi : Huron
{
    // POLYMORPHISM
    protected override void AtaqueEspecial()
    {
        Debug.Log("Popita acelera a gran velocidad.");
     //   controlJuego.ataqueEspecial.text = "Popita acelera a gran velocidad.";
    }
}
