using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBodyToBody : MonoBehaviour
{

    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dangerGolpe;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSiguienteAtaque;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        //if (tiempoSiguienteAtaque > 0)
        //{
        //    tiempoSiguienteAtaque -= Time.deltaTime;
        //}
        //if (Input.GetKeyDown("b") && tiempoSiguienteAtaque <=  0)
        //{
        //    Golpe();
        //    tiempoSiguienteAtaque = tiempoEntreAtaque;
        //}
    }*/

    public void TiempoEntreAtaque()
    {
       // Debug.Log($"Tiempo entre ataque es {tiempoEntreAtaque}");
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

    }
    public void Ataque()
    {

        if (tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaque;
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);


        foreach (Collider2D collisionador in objetos)
        {

            if (collisionador.CompareTag("Jefe") )
            {
                collisionador.GetComponent<Jefe>().TomarDanno(dangerGolpe);
                Debug.Log(collisionador.name);
            }
           
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
