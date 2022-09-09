using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour
{
    [SerializeField] private Animation _animator;
    [SerializeField] private GameObject _particle;
    [SerializeField] private Transform _point;

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Ball ball))
        {
            Instantiate(_particle, _point.position, Quaternion.identity);
            _animator.CloseDoor();
        }
    }
}
