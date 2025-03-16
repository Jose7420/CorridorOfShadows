using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LanceTrapController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject traps;

    private void Start()
    {
        traps = GameObject.FindGameObjectWithTag("Lance");
        traps.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            traps.SetActive(true);
            _audioSource.Play();

        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        traps.SetActive(false);
        _audioSource.Stop();
    }
}
