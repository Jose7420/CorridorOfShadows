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

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke(nameof(Launch),0.5f); 
        time = _shoot;
        _audioSource = transform.parent.GetComponent<AudioSource>();

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
        _audioSource.Stop();
        yield return new WaitForSeconds(delay);
        Launch();
    }


    private void Launch()
    {
        var obj = Instantiate(dardo, transform.position, transform.rotation);
        Destroy(obj,0.5f);
       _audioSource.Play();
       // Debug.Log("Launched dardo"+dardo.name);

    }



}
