using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int jump;
    private bool ground;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private Joystick joystick;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(joystick.Horizontal * speed, rb.velocity.y);
        if (joystick.Horizontal != 0)
            anim.SetBool("Isrun", true);
        else if (joystick.Horizontal == 0)
            anim.SetBool("Isrun", false);
        if (joystick.Vertical >= 0.5f)
        Jump();
        Flip();
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
}
