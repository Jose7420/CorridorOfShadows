using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Mover al jugador
            collision.transform.position = new Vector2(transform.position.x - 5, collision.transform.position.y);
            // Desactivar el objeto padre
            if (transform.parent != null)
            {
                transform.parent.gameObject.SetActive(false);
                GameManagerLocal.Instance.removePoints(5);

            }
        }
    }
}
