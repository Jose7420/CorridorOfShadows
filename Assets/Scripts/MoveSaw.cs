using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class MoveSaw : MonoBehaviour
{

    [SerializeField] private float speed = 200f;//-0.8f;

    private  static bool iSRotate = false;

    public static bool IsRotate
    {
        get { return iSRotate; }
        set { iSRotate = value; }   
    }
  

   
   
    public  bool IsSierraRotate {  get;  set; }
    // Start is called before the first frame update
    void Start()
    {
        speed = 200f;//-0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (iSRotate)
        {
           //transform.Rotate(0, 0, speed);
           transform.rotation = Quaternion.Euler(0, 0, speed * Time.deltaTime) * transform.rotation;
            
        }
        
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
                GameManagerLocal.Instance.RemovePoints(5);
              
            }
        }
    }

}
