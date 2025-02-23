using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamare : MonoBehaviour
{
    
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private float max = 96f;//87.81746f;//63.28464f;
    [SerializeField] private float min = -8.01f;//11.17465f;//-4f;//-4.897751f;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
       // Debug.Log($"La posicion de la camara es {cam.transform.position}");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        if (player.transform.position.x >= min && player.transform.position.x <= max)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
    
    
}
