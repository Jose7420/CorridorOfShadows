using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbodyPlayer;
    private Vector2 _direction;
    private float _jump;

    [SerializeField] private float _speed = 500;
    [SerializeField] private float _jumpForce = 10f;
    private bool _isGrounded;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [SerializeField] private float minX = -15.7f;
    [SerializeField] private float maxX = 114.5f; //74f;

    [SerializeField] private float danno;
    [SerializeField] private float vida = 50;

    private enum Jumping : ushort { up = 1 };


    private CombatBodyToBody _combatBodyTobody;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbodyPlayer = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _combatBodyTobody = GetComponent<CombatBodyToBody>();

    }

    // Update is called once per frame
    void Update()
    {
        _direction = _playerInput.actions["Movimientos"].ReadValue<Vector2>();
        _jump = _playerInput.actions["Jump"].ReadValue<float>();

        _combatBodyTobody.TiempoEntreAtaque();
        if (_playerInput.actions["Golpe"].WasPressedThisFrame())
        {
            _combatBodyTobody.Ataque();
        }

    }

    private void FixedUpdate()
    {
        MovePlayer(_direction.x * _speed * Time.fixedDeltaTime);
    }

    #region Colisiones

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = collision.gameObject.CompareTag("Ground");
    }

    #endregion

    #region Movimiento del player

    /// <summary>
    /// Mueve al Player cuando se pulsan los botones de direccion y este est� en el suelo.
    /// </summary>
    /// <param name="move">El valor del movimiento horizontal.</param>    
    private void MovePlayer(float move)
    {

        if (_isGrounded && _jump == 0)
        {
            //Debug.Log($"La variable _jump es {_jump}");
            //Debug.Log($"La variable _direction es {_direction}.");

            FlipSprite(_direction.x);

            _animator.SetBool("isStatic", IsPlayerStatic(_direction.x));
            _animator.SetBool("jump", false);

            _rigidbodyPlayer.velocity = new Vector2(move, _rigidbodyPlayer.velocity.y);
            _rigidbodyPlayer.position = new Vector2(Mathf.Clamp(_rigidbodyPlayer.position.x, minX, maxX),
                _rigidbodyPlayer.position.y);
        }

        JumpPlayer(move);


    }

    /// <summary>
    /// Comprueba si se a pulsado la tecla o el boton de salto
    /// y si el Player esta en el suelo para poder saltar.
    /// </summary>
    private void JumpPlayer(float move)
    {
        if (_jump == 1 && _isGrounded)
        {

            _isGrounded = false;

            // Para la velocidad del player
            _rigidbodyPlayer.velocity = Vector2.zero;

            // dar un impulso horizontal y vertical.
            _rigidbodyPlayer.AddForce(new Vector2(move * .30f, (int)Jumping.up * _jumpForce), ForceMode2D.Impulse);

            _animator.SetBool("isStatic", true);
            _animator.SetBool("jump", true);


        }
    }

    #endregion

    #region Cambiar de flip

    /// <summary>
    ///  Cambia la direcci�n del sprite si se est� moviendo.
    /// </summary>
    /// <param name="direction">La direcci�n en la que el sprite se est� moviendo.</param>
    private void FlipSprite(float direction)
    {
        if (direction == 0) return;
        // _spriteRenderer.flipX = direction < 0;

       
        transform.rotation = Quaternion.Euler(0, direction > 0 ? 0 : 180, 0);
    }

    #endregion

    #region Ver el estado isStatic

    /// <summary>
    /// Comprueba si el player est� parado    
    /// </summary>
    /// <param name="direction">La direcci�n del movimiento del player</param>
    /// <returns>True si el player esta parado; de lo contario, False.</returns>
    private bool IsPlayerStatic(float direction)
    {
        return direction == 0;
    }

    #endregion



    public void TomarDanno(float danno)
    {
        vida -= danno;

        if (vida <= 0)
        {
            _animator.SetTrigger("Muerte");
            transform.position=Vector2.zero;
            _animator.SetBool("isStatic", true);
            vida = 50;
        }
    }
}