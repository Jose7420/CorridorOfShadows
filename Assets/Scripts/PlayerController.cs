using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput _playerInput;
    private Vector2 movimiento;
    private float jump;

    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    private bool _IsGround;
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
        // jump = _playerInput.actions["Jump"].ReadValue<float>();
        // print(jump);
        
        jump = _playerInput.actions["Jump"].ReadValue<float>();
        Debug.Log($"Return {jump}");

         _jumpForce = 0;

         if (jump == 1 && _IsGround)
         {
             _IsGround = false;
             _jumpForce = 100f;
             Debug.Log("Dentro del condicional " + _IsGround);
         }

         

      



        transform.Translate(movimiento.x * _speed * Time.fixedDeltaTime,
            (jump * _speed  + _jumpForce) * Time.fixedDeltaTime, 0);
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("suelo");
        _IsGround = collision.gameObject.CompareTag("Ground");
       // Debug.Log(_IsGround);
    }
}