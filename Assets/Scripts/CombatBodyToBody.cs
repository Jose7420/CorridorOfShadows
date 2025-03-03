using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBodyToBody : MonoBehaviour
{

    [SerializeField] private Transform _hitController;
    [SerializeField] private float _hitRadius;
    [SerializeField] private float _hitDamage;
    [SerializeField] private float _timeBetweenAttack;
    [SerializeField] private float _TimeNextAttack;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        //if (_TimeNextAttack > 0)
        //{
        //    _TimeNextAttack -= Time.deltaTime;
        //}
        //if (Input.GetKeyDown("b") && _TimeNextAttack <=  0)
        //{
        //    Golpe();
        //    _TimeNextAttack = _timeBetweenAttack;
        //}
    }*/

    public void TimeBetweenAttack()
    {
       // Debug.Log($"Tiempo entre ataque es {tiempoEntreAtaque}");
        if (_TimeNextAttack > 0)
        {
            _TimeNextAttack -= Time.deltaTime;
        }

    }
    public void Stroke()
    {

        if (_TimeNextAttack <= 0)
        {
            Hit();
            _TimeNextAttack = _timeBetweenAttack;
        }
    }

    private void Hit()
    {
        _animator.SetTrigger("Hit");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(_hitController.position, _hitRadius);


        foreach (Collider2D collisionador in objetos)
        {

            if (collisionador.CompareTag("Jefe") )
            {
                collisionador.GetComponent<Jefe>().TakeDamage(_hitDamage);
                Debug.Log(collisionador.name);
            }
           
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_hitController.position, _hitRadius);
    }
}
