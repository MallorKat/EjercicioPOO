using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuca : MonoBehaviour, IDa�o
{
    public void HacerDa�o(int da�o)
    {
        Destroy(gameObject);
        Debug.Log("Comiendo!!!");
    }
}

