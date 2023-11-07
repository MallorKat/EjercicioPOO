using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    // Usaremos variables Transform para definir el objeto al que seguiremos.
    [SerializeField]
    private Transform seguirM;
    [SerializeField]
    private Transform seguirP;
    [SerializeField]
    private Transform seguirT;

    private Transform seguirH;

    // Esta variable controla el �ngulo en que la c�mara rotar�.
    // Modificamos el �ngulo para que la c�mara se inicie detr�s del jugador.
    // Para hacer que tambi�n se mueva en vertical usamos un Vector2
    private Vector2 angulo = new Vector2(90 * Mathf.Deg2Rad, 0);

    // Distancia de la c�mara con respecto al jugador.
    [SerializeField]
    private float distancia;
    // Establecemos la sensibilidad de la c�mara.
    [SerializeField]
    private Vector2 sensibilidad;

    void Start()
    {
        // Esta linea hace desaparecer el mouse e impide que pulsemos cerrar o minimizar.
        // He tenido que poner el UnityEngine, es posible que si se compila no funcione esta linea bien.
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        //if (DatosJuego.Instance.pochi == 1)
        //{
            seguirH = seguirT;
        //}
        //if (DatosJuego.Instance.pochi == 2)
        //{
        //    seguirH = seguirP;
        //}
        //if (DatosJuego.Instance.pochi == 3)
        //{
        //    seguirH = seguirM;
        //}
    }
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        // Si rotaci�n es diferente de 0, es decir, estoy moviendo el mouse, actualizamos el �ngulo.
        if (hor != 0)
        {
            // Aqu� movemos el �ngulo en positivo o negativo dependiendo del valor de rotaci�n, y luego lo multiplicamos para convertirlo de grados a radiales.
            // Es decir, si movemos el rat�n una unidad el �ngulo se mover� 1 radial, esto lo hacemos porque las operaciones de seno y coseno que usaremos usan radiales.
            angulo.x += hor * Mathf.Deg2Rad * sensibilidad.x;
        }
        if (ver != 0)
        {
            angulo.y += ver * Mathf.Deg2Rad * sensibilidad.y;

            // Con Clamp hacemos que la c�mara no se pueda mover m�s que entre dos valores, un m�nimo y un m�ximo.
            // El valor que queremos limitar el el angulo y, despu�s establecemos el m�nimo y tambi�n lo pasamos a radial, y finalmente el m�ximo tb en radial.
            angulo.y = Mathf.Clamp(angulo.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);
        }
    }

    void LateUpdate()
    {
        // Creamos una nueva variable que servir� para que la c�mara orbite alrededor del jugador.
        Vector3 orbita = new Vector3(Mathf.Cos(angulo.x) * Mathf.Cos(angulo.y), -Mathf.Sin(angulo.y), -Mathf.Sin(angulo.x) * Mathf.Cos(angulo.y));

        transform.position = seguirH.position + orbita * distancia;

        // Para hacer que la c�mara mire al jugador la rotamos haciendo que sea igual a Quaternion.LookRotation, esto devuelve la rotaci�n en una direcci�n.
        // En este caso ser�a la posici�n del jugador menos la posici�n de la c�mara.
        transform.rotation = Quaternion.LookRotation(seguirH.position - transform.position);
    }
}
