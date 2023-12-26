using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    [SerializeField]
    private float _velocidad = 10.0f;
    [SerializeField]
    private Vector3 _PosicionInicial = new(0, -3.25f, 0);
    [SerializeField]
    private float _horizontalInput;
    [SerializeField]
    private float _verticalInput;
    [SerializeField]
    private GameObject _LaserPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;
    [SerializeField]
    private float _nextFire = 0.0f;

    void Start()
    {
        // Posicionar Nave en Posicion Inicial
        transform.position = _PosicionInicial;
    }

    void Update()
    {
        Movement();
        Shoot();
    }

    private void Shoot()
    {
        // Si presiono tecla espacio o click izquierdo del mouse
        // Crear laser arriba de la posicion del Player
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && (Time.time > _nextFire))
        {
            // Cooldown
            _nextFire = Time.time + _fireRate;
            // Crear mi laser
            Instantiate(_LaserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        int moverHorizontal = 0;
        int moverVertical = 0;

        if (_horizontalInput > 0.15)
            moverHorizontal = 1;
        if (_horizontalInput < -0.15)
            moverHorizontal = -1;
        if (_horizontalInput == 0)
            moverHorizontal = 0;

        if (_verticalInput > 0.15)
            moverVertical = 1;
        if (_verticalInput < -0.15)
            moverVertical = -1;
        if (_verticalInput == 0)
            moverVertical = 0;

        // Control normal
        // Eje X
        if (transform.position.x >= -7.5 && transform.position.x <= 7.5 )
        {
            transform.Translate(Vector3.right * Time.deltaTime * _velocidad * moverHorizontal);
        }
        // Eje Y
        if (transform.position.y >= -4.25f && transform.position.y <= 1.25f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _velocidad * moverVertical);
        }

        // Control al llegar a un borde
        // Eje X
        if (transform.position.x >= 7.5 && _horizontalInput < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _velocidad * moverHorizontal);
        }
        if (transform.position.x <= -7.5 && _horizontalInput > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _velocidad * moverHorizontal);
        }        
        // Eje Y
        if (transform.position.y >= 1.25f && _verticalInput < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _velocidad * moverVertical);
        }
        if (transform.position.y <= -4.25f && _verticalInput > 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _velocidad * moverVertical);
        }
    }
}
