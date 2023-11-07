using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuca : MonoBehaviour, IDaño
{
    public void HacerDaño(int daño)
    {
        Destroy(gameObject);
        Debug.Log("Comiendo!!!");
    }
}

