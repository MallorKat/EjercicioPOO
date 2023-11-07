using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Trasto : Huron
{
    // POLYMORPHISM
    protected override void AtaqueEspecial()
    {
        Debug.Log("Trasto trepa por varias superficies verticales.");
        controlJuego.ataqueEspecial.text = "Trasto trepa por varias superficies verticales.";
    }
}

