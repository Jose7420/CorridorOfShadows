using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DardoController : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
        // Destroy(collision.gameObject);
         Destroy(gameObject);
      }
      Debug.Log(collision.gameObject.name);
   }
}
