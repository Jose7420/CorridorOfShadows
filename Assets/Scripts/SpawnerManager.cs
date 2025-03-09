using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemigos;
    private float positionY;
    private float positionX;
    private float offset = 0.5f;
    [SerializeField,Range(1,5)] private int numeroDeEnemigos;
    private float temporizador = 1;//0.5f;
    private int index;
    
    private Dictionary<int,string> colors = new Dictionary<int,string>()
    {
        { 0,"red"},
        { 1,"green"},
        { 2,"blue"},
        { 3,"yellow"},
        { 4,"purple"},
        { 5,"orange"},
        { 6,"pink"},
        { 7,"purple"},
        { 8,"orange"},
        { 9,"pink"},
        { 10,"purple"},
        
    };
   
    
    // Start is called before the first frame update
    void Start()
    {
        //numeroDeEnemigos = 1;
        index = enemigos.Length;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        temporizador -= Time.deltaTime;
        if (temporizador < 0  )
        {
            for(int i = 0; i < numeroDeEnemigos; i++)
            {
                positionY =Random.Range(0.5f, 4.84f);
                positionX = Random.Range(transform.position.x, transform.position.x + offset);
                index= Random.Range(0,enemigos.Length);

                Instantiate(enemigos[index], new Vector3(transform.position.x,positionY, transform.position.z), enemigos[index].transform.rotation);
               
            }

            temporizador = 1f;
        }
    }
}
