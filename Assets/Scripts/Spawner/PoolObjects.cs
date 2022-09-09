using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] private List<Ball> _balls;
    [SerializeField] private int _objectCount;

    private List<Ball> _poolBalls = new List<Ball>();

    private void Start()
    {
        for (int i = 0; i < _objectCount; i++)
        {
            SpawnBalls();
        }
    }

    private Ball SpawnBalls()
    {
        int randomValue = Random.Range(0, 3);
        Ball ball = Instantiate(_balls[randomValue]);
        ball.gameObject.SetActive(false);
        _poolBalls.Add(ball);
        Debug.Log(_poolBalls.Count);

        return ball;
    }

    public Ball GetFreeBall()
    {
        Ball ball = _poolBalls.FirstOrDefault(x => x.gameObject.activeSelf == false);
      
        if (ball == null)
        {
           return SpawnBalls();
        }
        else 
        {
            return ball;
        }
    }

    public void RemoveCombiningBall(Ball ball, Ball ball1)
    {
        _poolBalls.Remove(ball);
        _poolBalls.Remove(ball1);
    }

    public Ball GetRightBall(int dergee)
    {
        Debug.Log(dergee);
       Ball ball = _balls[dergee];
        return ball;
    }
}
