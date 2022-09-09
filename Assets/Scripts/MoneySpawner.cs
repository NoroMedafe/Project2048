using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _duration;

    public void SpawnMoney(Vector3 spawnPoint)
    {
       Money money =  Instantiate(_money, spawnPoint, Quaternion.identity);
       money.transform.DOMove(_endPoint.position, _duration).OnComplete(() => Destroy(money.gameObject));
    }
}
    