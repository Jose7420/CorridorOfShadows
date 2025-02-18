using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DardoController : MonoBehaviour
{

   // [SerializeField] private Transform circle;

    private void Start()
    {
      //  circle= GetComponent<Transform>();
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
        // Destroy(collision.gameObject);
         Destroy(gameObject);
         GameManagerLocal.Instance.removePoints(2);
      }
      Debug.Log(collision.gameObject.name);
   }
}
