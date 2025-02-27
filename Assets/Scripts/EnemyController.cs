using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbodyPlayer;

    [Header("Velocidad del enemigo")] 
    [SerializeField] private float speed = 15;//50f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbodyPlayer.AddForce( speed * Time.deltaTime * Vector2.left , ForceMode2D.Impulse);

        if (transform.position.x <= -17.33)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManagerLocal.Instance.AddPoints(5);
        Destroy(gameObject,0.1f);
    }

  
}
