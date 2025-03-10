using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ContollerCircle : MonoBehaviour
{

    private float time;
   [SerializeField] private float _shoot = 1f;
    public GameObject dardo;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke(nameof(Launch),0.5f); 
        time = _shoot;

        //StartCoroutine(LaunchWithDelay(0.5f));
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < Time.deltaTime)
        {
            time = _shoot;
            StartCoroutine(LaunchWithDelay(0.5f));
        }
    }

    private IEnumerator LaunchWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Launch();
    }


    private void Launch()
    {
        var obj = Instantiate(dardo, transform.position, transform.rotation);
        Destroy(obj,0.5f);
        Debug.Log("Launched dardo"+dardo.name);

    }



}
