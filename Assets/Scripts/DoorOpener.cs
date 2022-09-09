using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animation _animator;
    [SerializeField] private Vector3 _velocity;
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Ball ball))
        {
            _animator.OpenDoor();

            Vector3 velocity = ball.Rigidbody.velocity;
            ball.Rigidbody.velocity = velocity + _velocity;
        }
    }
   
}
