using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBall : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Vector3 _forceRight;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
            ball.Rigidbody.AddForce(Vector3.right * _force * -1, ForceMode.Impulse);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
            ball.Rigidbody.AddForce(Vector3.right + _forceRight, ForceMode.Impulse);
    }
}
