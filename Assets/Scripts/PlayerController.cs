using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput _playerInput;
    Rigidbody2D _RigidbodyPlayer;
    private Vector2 movimiento;
    private float jump;

    [SerializeField] float _speed = 10f;
    [SerializeField] float _jumpForce = 0f;
    private bool _IsGround;

    [SerializeField] private float minX = -17f;
    [SerializeField] private float maxX = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _RigidbodyPlayer = GetComponent<Rigidbody2D>();
        _speed = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        movimiento = _playerInput.actions["Movimientos"].ReadValue<Vector2>();
        jump = _playerInput.actions["Jump"].ReadValue<float>();

    }

    private void FixedUpdate()
    {

        Mover();
        Jump();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _IsGround = collision.gameObject.CompareTag("Ground");
        Debug.Log($"Dentro del collision {_IsGround}");
    }



    private void Jump()
    {

        _jumpForce = 0;

        if (jump == 1 && _IsGround)
        {
            _IsGround = false;
            _jumpForce = 10f;

            _RigidbodyPlayer.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            Debug.Log("Dentro del condicional " + _IsGround);
        }

    }

    private void Mover()
    {

        _RigidbodyPlayer.transform.Translate(Mathf.Clamp(movimiento.x * _speed * Time.fixedDeltaTime, minX, maxX), 0, 0);
    }

}