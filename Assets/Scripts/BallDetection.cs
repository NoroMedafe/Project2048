using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            ball.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            ball.transform.SetParent(transform);
        }
    }
}
