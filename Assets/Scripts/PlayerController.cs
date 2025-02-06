using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput _playerInput;
    private Vector2 movimiento;

    [SerializeField] float _speed;
    [SerializeField] float _jumpForce; 
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        movimiento = _playerInput.actions["Movimientos"].ReadValue<Vector2>();
        if (movimiento.y > 0)
        {
            _jumpForce = 10f;
        }
        else
        {
            _jumpForce = 0f;
        }

        transform.Translate(movimiento.x * _speed * Time.deltaTime,
            (movimiento.y * _speed + _jumpForce) * Time.deltaTime, 0);
    }

  

}