using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TrampasContoller : MonoBehaviour
{

    [SerializeField] private GameObject sierra;

    private void Start()
    {
        sierra = GameObject.FindGameObjectWithTag("Sierra");
        sierra.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
              sierra.SetActive(true);  
               
        }
    }
}
