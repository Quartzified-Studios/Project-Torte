using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera instance;

    [HideInInspector]
    public Camera playerCam;

    [Header("Targets")]
    public Transform target;
    public Transform player;

    [Header("Options")]
    public float smoothSpeed = 0.15f;
    public Vector3 offset;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        playerCam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            // Desired Position to Reach
            Vector3 desPos = target.position + offset;

            // Smoothed Position from Cam Pos to Target Pos
            Vector3 smoothPos = Vector3.Lerp(playerCam.transform.position, desPos, smoothSpeed);

            playerCam.transform.position = smoothPos;
        }
        else if(player != null)
        {
            // Desired Position to Reach
            Vector3 desPos = player.position + offset;

            // Smoothed Position from Cam Pos to Player Pos
            Vector3 smoothPos = Vector3.Lerp(playerCam.transform.position, desPos, smoothSpeed);

            playerCam.transform.position = smoothPos;
        }
    }

    //Function to set Target
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    //Remove Target
    public void RemoveTarget()
    {
        target = null;
    }
}
