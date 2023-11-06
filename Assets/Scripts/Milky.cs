using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Milky : Huron
{
    // POLYMORPHISM
    protected override void AtaqueEspecial()
    {
        Debug.Log("Milky suelta po po mientras avanza.");
      //  controlJuego.ataqueEspecial.text = "Milky suelta po po mientras avanza.";
    }
}

