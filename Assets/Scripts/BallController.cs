using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ShootByArrowDirection))]

public class BallController : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody ballRigidbody;
    private ShootByArrowDirection shootByArrowDirection;
    private bool ballMoving;
    


    void Start()
    {
        // Ball rigidbody and start position
        initialPosition = transform.position;
        ballRigidbody = GetComponent<Rigidbody>();
        shootByArrowDirection = GetComponent<ShootByArrowDirection>();
    }

    public void ResetBall()
    {
        // Reset Ball position and velocity
        transform.position = initialPosition;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        shootByArrowDirection.EnableArrowRenderer();
        SetBallMoving(false);
    }

    public bool IsBallMoving()
    {
        return ballMoving;
    }

    public void SetBallMoving(bool state)
    {
        ballMoving = state;
    }
}
