using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Mover al jugador
            other.transform.position = new Vector2(transform.position.x - 5, other.transform.position.y);
            // Desactivar el objeto padre
            if (transform.parent != null)
            {
                transform.parent.gameObject.SetActive(false);
                GameManagerLocal.Instance.RemovePoints(5);

            }
        }
    }
}
