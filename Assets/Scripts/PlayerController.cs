using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody2D _RigidbodyPlayer;
    private Vector2 direction;
    private float jump;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private bool _IsGround;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private float minX = -15.7f;
    [SerializeField] private float maxX = 114.5f;//74f;


    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _RigidbodyPlayer = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // _speed = 10f;
        _speed = 500;
        _jumpForce = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        direction = _playerInput.actions["Movimientos"].ReadValue<Vector2>();
        jump = _playerInput.actions["Jump"].ReadValue<float>();

    }

    private void FixedUpdate()
    {
        Mover(direction.x * _speed * Time.fixedDeltaTime);
    }

    #region Collisiones

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _IsGround = collision.gameObject.CompareTag("Ground");

    }
    #endregion

    #region Movimiento player

    /// <summary>
    /// Mover al player cuando se pulse los botones de direcion
    /// </summary>
    /// <param name="mover"></param>    
    private void Mover(float mover)
    {
        if (_IsGround)
        {
            ChangeFlip(direction.x);
            animator.SetBool("isStatic", IsStatic(direction.x));

            _RigidbodyPlayer.velocity = new Vector2(mover, _RigidbodyPlayer.velocity.y);

            _RigidbodyPlayer.position = new Vector2(Mathf.Clamp(_RigidbodyPlayer.position.x, minX * 1f, maxX),
                _RigidbodyPlayer.position.y);
        }
        Jump();


    }


    /// <summary>
    /// Comprobar si se a pulsado la tecla o el boton de salto
    /// y si esta en tierra para saltar
    /// </summary>
    private void Jump()
    {

        // Comprobar si esta en el suelo y el salto es hacia arriba
        if (jump == 1 && _IsGround)
        {
            _IsGround = false;
            // _jumpForce = 10f;

            _RigidbodyPlayer.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isStatic", IsStatic(direction.y));
            // Debug.Log("Dentro del condicional " + _IsGround);
        }

    }
    #endregion

    #region Cambiar de flip

    /// <summary>
    /// Cambiar la direccion del sprite
    /// se manda la direcion por parametros el valor de tipo float donde quiere que mire el sprite
    /// </summary>
    /// <param name="direction"></param>
    private void ChangeFlip(float direction)
    {

        if (direction == 0) return;
        spriteRenderer.flipX = direction < 0;

    }
    #endregion

    #region Ver el estado istatic

    /// <summary>
    /// Comprobar si el player esta parado
    /// se mando por parametro la direcion si es cero devuelve true.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private bool IsStatic(float direction)
    {
        return direction == 0;

    }
    #endregion


}