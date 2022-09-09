using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombiningBalls : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private PoolObjects _poolObjects;
    [SerializeField] private GameObject _particle;
    [SerializeField] private MoneySpawner _money;
 
    private void SpawnConnectedBall(Ball currentBall, Ball ball1)
    {
        ball1.BallConnected -= SpawnConnectedBall;
        currentBall.BallConnected -= SpawnConnectedBall;

        int degree = (int)Mathf.Log(currentBall.Capasity, 2);

        Ball newBall = Instantiate(_poolObjects.GetRightBall(degree), currentBall.CentralPoint, Quaternion.identity);
        Instantiate(_particle, currentBall.transform.position + Vector3.back, Quaternion.identity);

        OnBallSpawned(newBall);

        _poolObjects.RemoveCombiningBall(currentBall, ball1);
        _money.SpawnMoney(currentBall.CentralPoint);

        Destroy(currentBall.gameObject);
        Destroy(ball1.gameObject);
    }

    private void OnBallSpawned(Ball ball)
    {
        ball.BallConnected += SpawnConnectedBall;
    }

    private void OnEnable()
    {
        _spawner.BallSpawned += OnBallSpawned;
    }

    private void OnDisable()
    {
        _spawner.BallSpawned -= OnBallSpawned;
    }
}
