using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallTrigger : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody ballRigidbody;
    private ShootByArrowDirection shootByArrowDirection;
    private BallController ballController;
    void Start()
    {
        // Ball rigidbody and start position
        initialPosition = transform.position;
        ballRigidbody = GetComponent<Rigidbody>();
        shootByArrowDirection = GetComponent<ShootByArrowDirection>();
        ballController = GetComponent<BallController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetBallArea"))
        {
            
            ballController.ResetBall();
        }
    }
   
}

