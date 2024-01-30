using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ShootByArrowDirection : MonoBehaviour
{

    [SerializeField] float shootForce = 10f; // shoot force
    private Transform arrowTransform;
    private BallController ballController;
    private int shotsCount = 0;
    private bool isFirstShot = true;

    void Start()
    {
        ballController = GetComponent<BallController>();
    }

    void FixedUpdate()
    {
        if (ballController.IsBallMoving()) // if the ball in move dont add force
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !ballController.IsBallMoving()) // if the spece key was pressed and the ball not moving
        {
            arrowTransform = GameObject.FindGameObjectWithTag("Arrow").GetComponent<Transform>();
            if (shotsCount < 2) // checking the number of shoots
            {
                Shoot();
                isFirstShot = false;
            }
        }
    }

    void Shoot()
    {
        ballController.SetBallMoving(true);
        DisableArrowRenderer(); // disable the arrow renderer
        Rigidbody ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.AddForce(-arrowTransform.right * shootForce, ForceMode.Impulse); // Add force in the direction of the arrow
        shotsCount++; 
    }
    void DisableArrowRenderer()
    {
        GameObject arrow = GameObject.FindGameObjectWithTag("Arrow");
        MeshRenderer meshRenderer = arrow.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
    }

    public void EnableArrowRenderer()
    {
        GameObject arrow = GameObject.FindGameObjectWithTag("Arrow");
        MeshRenderer meshRenderer = arrow.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
        }
    }
    public bool IsfirstShoot()
    {
        return isFirstShot;
    }
    public int GetShotsCount()
    {
        return shotsCount;
    }

}
