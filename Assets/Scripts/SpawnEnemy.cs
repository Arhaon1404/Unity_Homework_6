using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _spawnableObject;
    [SerializeField] private Spawner[] Spawners;

    private Coroutine _spawnEnemyCoroutine;
    private int _randomPosition;
    private float _spawnSecondsPeriod = 2f;
    private bool _isDone = true;

    private void Update()
    {
        RunCoroutine();
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(_spawnSecondsPeriod);

        _randomPosition = Random.Range(0, Spawners.Length);

        Instantiate(_spawnableObject, Spawners[_randomPosition].transform.position, Quaternion.identity);

        _isDone = true; 
    }

    private void RunCoroutine()
    {
        if (_spawnEnemyCoroutine != null & _isDone == true)
        {
            StopCoroutine(_spawnEnemyCoroutine);
        }

        if (_isDone == true)
        {
            _isDone = false;
            _spawnEnemyCoroutine = StartCoroutine(SpawnObject());
        }
    }
}
