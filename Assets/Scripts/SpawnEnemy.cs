using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _spawnableObject;
    [SerializeField] private float _spawnSecondsPeriod;
    [SerializeField] private int _spawnCount;

    private Enemy _newObject;
    private Coroutine _spawnEnemyCoroutine;
    private bool _isDone = true;
    private int _counter;

    private void Start()
    {
        _counter = 0;
    }

    private void Update()
    {
        if (_counter < _spawnCount)
        {
            RunCoroutine();
        }
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(_spawnSecondsPeriod);

        _newObject = Instantiate(_spawnableObject, transform.position, Quaternion.identity);

        _newObject.GetComponent<Enemy>().GetTarget(_target);

        _isDone = true;

        _counter++;
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
