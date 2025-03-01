using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    public void TomarDanno(float danno)
    {
        vida -= danno;

        if(vida <= 0)
        {
            Muerte();
        }
    }


    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Destroy(gameObject);
    }

}
