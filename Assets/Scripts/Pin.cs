using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isFall;

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("Ball") || collision.collider.CompareTag("Pin")) && !isFall) // if the ball or another pin collide in pin, mark him as fell.
        {
            isFall = true;
        }
    }

    public bool IsFall()
    {
        return isFall;
    }
}
