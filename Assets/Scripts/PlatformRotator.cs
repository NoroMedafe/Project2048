using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private SwipeDetection _input;

    private void Update()
    {
        if (Mathf.Abs(_input.Direction) > 1)
            transform.Rotate(new Vector3(0, _input.Direction * Time.deltaTime * _speedRotation));
    }
}
