using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    [SerializeField] public Vector3 walls; // for fix camera exit outside the wall

    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    void Update()
    {
        CheckWallCam();
    }

    private void CheckWallCam()
    {
        transform.position = Player.transform.position + offset + walls;
    }
}