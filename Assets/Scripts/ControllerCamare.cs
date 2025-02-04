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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
