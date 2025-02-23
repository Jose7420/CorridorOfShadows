using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ContollerCircle : MonoBehaviour
{

    public GameObject dardo;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke(nameof(Launch),0.5f); 

        StartCoroutine(LaunchWithDelay(0.5f));
    }

    private IEnumerator LaunchWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Launch();
    }


    private void Launch()
    {
        Instantiate(dardo, transform.position, transform.rotation);

    }



}
