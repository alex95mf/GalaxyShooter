using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables

    [SerializeField]
    private float velocidad = 10.0f;
    [SerializeField]
    private Vector3 PosicionInicial = new(0, -3.25f, 0);
    [SerializeField]
    private float horizontalInput;
    [SerializeField]
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        // Posicionar Nave en Posicion Inicial
        transform.position = PosicionInicial;
    }

    void Update()
    {
        Movement();
    }

    // Update is called once per frame
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        int moverHorizontal = 0;
        int moverVertical = 0;

        if (horizontalInput > 0.15)
            moverHorizontal = 1;
        if (horizontalInput < -0.15)
            moverHorizontal = -1;
        if (horizontalInput == 0)
            moverHorizontal = 0;

        if (verticalInput > 0.15)
            moverVertical = 1;
        if (verticalInput < -0.15)
            moverVertical = -1;
        if (verticalInput == 0)
            moverVertical = 0;

        // Control normal
        // Eje X
        if (transform.position.x >= -7.5 && transform.position.x <= 7.5 )
        {
            transform.Translate(Vector3.right * Time.deltaTime * velocidad * moverHorizontal);
        }
        // Eje Y
        if (transform.position.y >= -4.25f && transform.position.y <= 1.25f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * velocidad * moverVertical);
        }

        // Control al llegar a un borde
        // Eje X
        if (transform.position.x >= 7.5 && horizontalInput < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * velocidad * moverHorizontal);
        }
        if (transform.position.x <= -7.5 && horizontalInput > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * velocidad * moverHorizontal);
        }        
        // Eje Y
        if (transform.position.y >= 1.25f && verticalInput < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * velocidad * moverVertical);
        }
        if (transform.position.y <= -4.25f && verticalInput > 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * velocidad * moverVertical);
        }
    }
}
