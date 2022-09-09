using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBallFly : MonoBehaviour
{
    [SerializeField] private float _force;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
            ball.Rigidbody.AddForce(Vector3.down * _force, ForceMode.Impulse);
    }
}
