using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamare : MonoBehaviour
{
    
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log($"La posicion de la camara es {cam.transform.position}");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= -3.91997 && player.transform.position.x <= 38.99144)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
    
    
}
