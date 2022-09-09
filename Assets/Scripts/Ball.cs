using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour
{
    [SerializeField] private int _capasity;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _duration;

    public Vector3 CentralPoint;

    private Rigidbody _rigidbody;

    private const float CentralFormule = 0.5f;

    public event Action<Ball,Ball> BallConnected;

    public int Capasity => _capasity;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.TryGetComponent(out Ball ball))
        {

            if (Capasity == ball.Capasity)
            {
                _rigidbody.velocity = Vector3.zero;
                CentralPoint = (transform.position + ball.transform.position) * CentralFormule;
                _collider.isTrigger = true;

                transform.DOMove(CentralPoint, _duration).OnComplete(() => BallConnected?.Invoke(this, ball));
            }
        }
    }
}
