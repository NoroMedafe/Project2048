using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _spawnDelay;
    [SerializeField] private PoolObjects _poolBalls;

    public event Action<Ball> BallSpawned;

    private void Start()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            Ball ball = _poolBalls.GetFreeBall();
           
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);

            BallSpawned?.Invoke(ball);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
