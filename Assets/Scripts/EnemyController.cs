using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _RigidbodyPlayer;

    [Header("Velocidad del enemigo")] [SerializeField]
    private float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        _RigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _RigidbodyPlayer.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);

        if (transform.position.x <= -17.33)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManagerLocal.Instance.addPoints(5);
        Destroy(gameObject,0.1f);
    }

  
}
