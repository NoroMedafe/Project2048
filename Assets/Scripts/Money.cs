using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private Vector3 _speedRotation;

    private void Update()
    {
        transform.Rotate(_speedRotation);
    }
}
