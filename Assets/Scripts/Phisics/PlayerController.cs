using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    #region Singlton:PlayerController

    public static PlayerController Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    #endregion

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
		Debug.Log(ground.ToString());
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
        if (joystick.Vertical >= 0.5f)
            Jump();
        Attack();

        if (Input.GetKey("v"))
        {
            SceneManager.LoadScene("Shop");
        }

        /* Debug.Log(PlayerController.z);*/
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
            Equal();
            if (Time.time > nextfire)
            {
                Instantiate(Bullet, shotpos.transform.position, transform.rotation);
                nextfire = Time.time + cooldowntime;
            }
        }
        else if (btn_att_pos == btn_att.transform.position.y)
        {
            anim.SetBool("IsIdle", false);
            anim.SetBool("Is1", false);
            anim.SetBool("Is2", false);
            anim.SetBool("Is3", false);
            anim.SetBool("Is4", false);
            anim.SetBool("Is5", false);
        } 
    }

    private void Equal()
    {
        if (Profile.ProfileItem.Index == 0)
        {
            SetAnimSlowWand();
        }

        else if (Profile.ProfileItem.Index == 1)
        {
            SetAnimSlowWoodenClub();
        }

        else if (Profile.ProfileItem.Index == 2)
        {
            SetAnimSlowSpikedBaton();
        }

        else if (Profile.ProfileItem.Index == 3)
        {
            SetAnimSlowIronClub();
        }

        else if (Profile.ProfileItem.Index == 4)
        {
            SetAnimSlowAxe();
        }

        else if (Profile.ProfileItem.Index == 5)
        {
            SetAnimSlowAir();
        }
    }

    public void SetAnimSlowWand()
    {
        anim.SetBool("IsIdle", true);
    }

    public void SetAnimSlowWoodenClub()
    {
        anim.SetBool("Is1", true);
    }

    public void SetAnimSlowSpikedBaton()
    {
        anim.SetBool("Is2", true);
    }

    public void SetAnimSlowIronClub()
    {
        anim.SetBool("Is3", true);
    }

    public void SetAnimSlowAxe()
    {
        anim.SetBool("Is4", true);
    }

    public void SetAnimSlowAir()
    {
        anim.SetBool("Is5", true);
    }

}


