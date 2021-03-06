using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int jump;
    private bool ground;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private Joystick joystick;
    [SerializeField] private int health;
    public Transform boompos;
    public GameObject Boom;
    public float lifetime = 0.2f;
    [SerializeField] public Vector3 pos; // for fix otbros persa
    /*    private Animator camAnim;*/

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
/*        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();*/
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        rb.velocity = new Vector2(joystick.Horizontal * speed, rb.velocity.y);

        if (joystick.Horizontal != 0)
        {
            anim.SetBool("IsRun", true);
        }

        else if (joystick.Horizontal == 0)
        {
            anim.SetBool("IsRun", false);
        }

        Flip();
        if (joystick.Vertical >= 0.5f)
            Jump();
        IsDie();
    }

    private void IsDie()
    {
        if (health <= 0)
        {
            anim.SetBool("IsIdle", true);
            Invoke("Die", 0.5f);
        }
        else
        {
            anim.SetBool("IsIdle", false);
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Level");
    }

    private void Jump()
    {
        if (ground == true)
        {
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        if (joystick.Horizontal > 0)
/*            transform.localRotation = Quaternion.Euler(0, 180, 0);*/
        rb.velocity = new Vector2(-joystick.Horizontal * speed, rb.velocity.y);
        else if (joystick.Horizontal < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground")
            ground = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
            ground = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) //Died enemy
    {
        if (collision.CompareTag("Bullet"))
        {
            var boom = (GameObject) Instantiate(Boom, boompos.transform.position, transform.rotation);
/*            camAnim.SetTrigger("shake");*/
            transform.position = transform.position + pos;
            Destroy(boom, lifetime);
            health -= 5;
        }
    }
}
