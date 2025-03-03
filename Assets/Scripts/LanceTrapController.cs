using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LanceTrapController : MonoBehaviour
{

    [SerializeField] private GameObject traps;

    private void Start()
    {
        traps = GameObject.FindGameObjectWithTag("Lance");
        traps.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            traps.SetActive(true);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        traps.SetActive(false);
    }
}
