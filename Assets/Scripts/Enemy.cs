using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public int health;
    public Transform player;
    public GameObject bullet;
    [SerializeField]
    public float speed;
/*    private int kill;*/

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-player.transform.position.x * speed, rb.velocity.y);
        if (health < 0)
        {
            Destroy(gameObject);
/*            Debug.Log(kill);*/
        }

/*        while(health < 0)
        {
            kill++;
            Debug.Log(kill);
        }*/
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
            {
               health -= 5;
            }
/*        if (health < 0)
        {
            Destroy(bullet);
        }*/
    }
}

