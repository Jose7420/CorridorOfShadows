using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class MoveSaw : MonoBehaviour
{
    
    [SerializeField] private float speed = -0.8f;
    // Start is called before the first frame update
    void Start()
    {
        speed = -0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,speed);
    }

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
            }
        }
    }
}
