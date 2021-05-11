using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    [SerializeField] public Vector3 walls; // for fix camera exit outside the wall
/*    private Animator anim;*/

    void Start()
    {
        offset = transform.position - Player.transform.position;
/*        anim = GetComponent<Animator>();*/
    }

    void Update()
    {
        CheckWallCam();
/*        anim.SetTrigger("shake");*/
    }

    private void CheckWallCam()
    {
        transform.position = Player.transform.position + offset + walls;
    }
}