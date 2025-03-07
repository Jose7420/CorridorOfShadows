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
    [SerializeField] private float _life;


    [Header("Ataque")]
    [SerializeField] private Transform _attackController;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _damage;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // _combatBodyTobody = GetComponent<CombatBodyToBody>();
    }

    private void Update()
    {
        float distanciaplayer = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("DistanciaPlayer", distanciaplayer);
        if (transform.position.x < 83 || transform.position.x >111 ) { transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0); }
     

    }


    public void TakeDamage(float damage)
    {
        _life -= damage;

        if (_life <= 0)
        {
            animator.SetTrigger("Death");
            Death();
        }
    }


    private void Death()
    {
        Destroy(gameObject, 3.15f);
    }

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




    public void Stoke()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(_attackController.position, _attackRadius);
        foreach (Collider2D objeto in objetos)
        {
                Debug.Log(objeto.tag);
            if (objeto.CompareTag("Player"))
            {
                objeto.GetComponent<PlayerController>().TakeDamage(_damage);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackController.position, _attackRadius);
    }





}
