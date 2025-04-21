using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Jefe : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb2D;

    public Rigidbody2D Rb2D { get { return rb2D; } }


    [SerializeField] private Transform player;


    // private CombatBodyToBody _combatBodyTobody;
    [SerializeField] private bool _lookToTheRight = true;

    [Header("Vida")]
    [SerializeField] private float _life = 150f;
    private static bool _isDeath = false;



    [Header("Ataque")]
    [SerializeField] private Transform _attackController;
    [SerializeField] private float _attackRadius = 2.36f;
    [SerializeField] private float _damage = 10f;

    [SerializeField] AudioClip _attackClip;
    private AudioSource _attackSource;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // _combatBodyTobody = GetComponent<CombatBodyToBody>();
        _attackSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float distanciaplayer = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("DistanciaPlayer", distanciaplayer);

        // comprobar que el jefe llegue a los limites y posicionarlo fuera del limite
        // y rotarlo en para la otra posicion.
        if (transform.position.x < 83 || transform.position.x > 113)
        {
            // Cuando llege al limite posicionarlo fuera de este.
            transform.position = new Vector3(transform.position.x < 85 ? 84 : 112, transform.position.y, transform.position.z);

            // Girar al jefe 180 grados.
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);


        }


    }

    /// <summary>
    /// Reduce la vida segun la cantidad de da�o recibido.
    /// Si la vida llega a cero, activa la animacion de "Muerte",
    /// otorgan puntos al player y comienza el proceso de finalizacion del juego.
    /// </summary>
    /// <param name="damage">Cantidad de da�o que se aplicara al Jefe.</param>

    public void TakeDamage(float damage)
    {
        _life -= damage;

        if (_life <= 0)
        {
            animator.SetTrigger("Death");
            GameManagerLocal.Instance.AddPoints(15);
            // Death();
            //GameManagerLocal.Instance.StopGame();

            StartCoroutine(nameof(FinalizeGame));
        }
    }



    private void Death()
    {

        //Destroy(gameObject, 3.15f);
        _isDeath = true;


    }

    /// <summary>
    /// Comprobar si el Jefe esta mirando al player 
    /// en la distancia establecida y sino lo esta
    /// se gira para esta enfrente de el.
    /// </summary>
    public void MirarPlayer()
    {


        if (((player.position.x > transform.position.x) && !_lookToTheRight)
            || ((player.position.x < transform.position.x) && _lookToTheRight))
        {
            //  Debug.Log($"Mirando hacia la derecha {_lookToTheRight}");

            _lookToTheRight = !_lookToTheRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            //Debug.Log($"Mirando hacia la derecha {_lookToTheRight} y el transforom {transform.eulerAngles}");
        }
    }



    /// <summary>
    /// Comprobar cuando se golpea el player esta dentro de ese radio de ataque.
    /// si esta se le quitara puntos y se activara el sonido del golpe.
    /// </summary>
    public void Stoke()
    {

        Collider2D[] objetos = Physics2D.OverlapCircleAll(_attackController.position, _attackRadius);
        foreach (Collider2D objeto in objetos)
        {
            Debug.Log(objeto.tag);
            if (objeto.CompareTag("Player"))
            {
                _attackSource.PlayOneShot(_attackClip);
                objeto.GetComponent<PlayerControllerCOS>().TakeDamage(_damage);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackController.position, _attackRadius);
    }

    /// <summary>
    /// Corrutina para indicar el fin del juego.
    /// </summary>
    /// <returns>la muerte del jefe</returns>
    private IEnumerator FinalizeGame()
    {

        Debug.Log("Esta es la finalizeGAmem antes de parar el juego");

        yield return new WaitForSeconds(4f);
        Debug.Log("finalizar juego");
        //GameManagerLocal.Instance.EndGame();
        Death();

    }

    /// <summary>
    /// Metodo estatico para saber si esta muerto.
    /// para que el gameManagerLocal pueda comprobar si esta
    /// muerto el jefe.
    /// </summary>
    /// <returns></returns>
    public static bool DeathBoss()
    {
        return _isDeath;

    }

}
