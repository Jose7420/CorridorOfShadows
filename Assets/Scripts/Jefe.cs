using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Jefe : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb2D;

    public Rigidbody2D Rb2D { get { return rb2D; } }


    public Transform player;


    // private CombatBodyToBody _combatBodyTobody;
    [SerializeField] private bool mirandoDerecha = true;
    [Header("Vida")]
    [SerializeField] private float vida;


    [Header("Ataque")]
    [SerializeField] private Transform controlladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danno;

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


    public void TomarDanno(float danno)
    {
        vida -= danno;

        if (vida <= 0)
        {
            animator.SetTrigger("Muerte");
            Muerte();
        }
    }


    private void Muerte()
    {
        Destroy(gameObject, 0.5f);
    }

    public void MirarPlayer()
    {


        if (((player.position.x > transform.position.x) && !mirandoDerecha)
            || ((player.position.x < transform.position.x) && mirandoDerecha))
        {
            Debug.Log($"Mirando hacia la derecha {mirandoDerecha}");

            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            Debug.Log($"Mirando hacia la derecha {mirandoDerecha} y el transforom {transform.eulerAngles}");
        }
    }




    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controlladorAtaque.position, radioAtaque);
        foreach (Collider2D objeto in objetos)
        {
                Debug.Log(objeto.tag);
            if (objeto.CompareTag("Player"))
            {
                objeto.GetComponent<PlayerController>().TomarDanno(danno);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controlladorAtaque.position, radioAtaque);
    }





}
