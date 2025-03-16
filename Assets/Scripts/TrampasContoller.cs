using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TrampasContoller : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject sierra;

    private void Start()
    {
        sierra = GameObject.FindGameObjectWithTag("Sierra");
        sierra.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
//     Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
              sierra.SetActive(true);  
              MoveSaw.IsRotate = true;
            _audioSource.Play();
             
               
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sierra.SetActive(false);
        _audioSource.Stop();
    }


}
