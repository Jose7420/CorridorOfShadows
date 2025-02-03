using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    PlayerInput _playerInput;
    private Vector2  movimiento;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = _playerInput.actions["Movimientos"].ReadValue<Vector2>();

        

        transform.Translate(movimiento.x *Time.deltaTime,movimiento.y * Time.deltaTime,0); 
        

    }
}
