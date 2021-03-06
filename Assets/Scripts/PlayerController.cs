using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int jump;
    public Transform tr;
    private bool ground;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private Joystick joystick;
    public GameObject btn_att;
    float btn_att_pos;
    public GameObject Bullet;
    public Transform shotpos;

    [SerializeField]
    private float cooldowntime = 0;
    private float nextfire = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        btn_att_pos = btn_att.transform.position.y;
        tr = GetComponent<Transform>();
        Vector3 pos = transform.position;

    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        rb.velocity = new Vector2(joystick.Horizontal * speed, rb.velocity.y);
        if (joystick.Horizontal != 0)
        {
            anim.SetBool("Isrun", true);
        }
        else if (joystick.Horizontal == 0)
        {
            anim.SetBool("Isrun", false);
        }
        Flip();
        Attack();
        if (joystick.Vertical >= 0.5f)
            Jump();
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
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (joystick.Horizontal < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
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

    private void Attack()
    {
        if (btn_att_pos != btn_att.transform.position.y)
        {
            anim.SetBool("IsIdle", true);
            if (Time.time > nextfire)
            {
                Instantiate(Bullet, shotpos.transform.position, transform.rotation);
                nextfire = Time.time + cooldowntime;
            }
        }
        else
        {
            anim.SetBool("IsIdle", false);
        }
    }
}

