using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContollerCircle : MonoBehaviour
{

    public GameObject dardo;
    // Start is called before the first frame update
    void Start()
    {
      Invoke(nameof(Launch),0.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Launch()
    {
        Instantiate(dardo, transform.position, transform.rotation);
      
    }
}
