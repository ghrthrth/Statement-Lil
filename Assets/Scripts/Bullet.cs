using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private bool enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            enemy = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            enemy = false;
    }

    private void Destroy()
    {
        if (enemy == true)
        {
            Destroy(gameObject);
        }
    }
}

