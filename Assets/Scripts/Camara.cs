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

    // Esta variable controla el ángulo en que la cámara rotará.
    // Modificamos el ángulo para que la cámara se inicie detrás del jugador.
    // Para hacer que también se mueva en vertical usamos un Vector2
    private Vector2 angulo = new Vector2(90 * Mathf.Deg2Rad, 0);

    // Distancia de la cámara con respecto al jugador.
    [SerializeField]
    private float distancia;
    // Establecemos la sensibilidad de la cámara.
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

        // Si rotación es diferente de 0, es decir, estoy moviendo el mouse, actualizamos el ángulo.
        if (hor != 0)
        {
            // Aquí movemos el ángulo en positivo o negativo dependiendo del valor de rotación, y luego lo multiplicamos para convertirlo de grados a radiales.
            // Es decir, si movemos el ratón una unidad el ángulo se moverá 1 radial, esto lo hacemos porque las operaciones de seno y coseno que usaremos usan radiales.
            angulo.x += hor * Mathf.Deg2Rad * sensibilidad.x;
        }
        if (ver != 0)
        {
            angulo.y += ver * Mathf.Deg2Rad * sensibilidad.y;

            // Con Clamp hacemos que la cámara no se pueda mover más que entre dos valores, un mínimo y un máximo.
            // El valor que queremos limitar el el angulo y, después establecemos el mínimo y también lo pasamos a radial, y finalmente el máximo tb en radial.
            angulo.y = Mathf.Clamp(angulo.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);
        }
    }

    void LateUpdate()
    {
        // Creamos una nueva variable que servirá para que la cámara orbite alrededor del jugador.
        Vector3 orbita = new Vector3(Mathf.Cos(angulo.x) * Mathf.Cos(angulo.y), -Mathf.Sin(angulo.y), -Mathf.Sin(angulo.x) * Mathf.Cos(angulo.y));

        transform.position = seguirH.position + orbita * distancia;

        // Para hacer que la cámara mire al jugador la rotamos haciendo que sea igual a Quaternion.LookRotation, esto devuelve la rotación en una dirección.
        // En este caso sería la posición del jugador menos la posición de la cámara.
        transform.rotation = Quaternion.LookRotation(seguirH.position - transform.position);
    }
}
