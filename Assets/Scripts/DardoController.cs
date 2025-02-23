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

   
    private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
        // Destroy(collision.gameObject);
         //Destroy(gameObject);
         GameManagerLocal.Instance.RemovePoints(2);
         
         collision.transform.position = new Vector2(transform.position.x - 5, collision.transform.position.y);
      }
      Debug.Log(collision.gameObject.name);
   }

 }
