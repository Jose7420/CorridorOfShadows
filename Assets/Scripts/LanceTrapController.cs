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
    traps= GameObject.FindGameObjectWithTag("Speartraps");
    traps.SetActive(false);
  }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.gameObject.tag);
    if (other.gameObject.CompareTag("Player"))
    {
      traps.SetActive(true);
    }
  }
}
