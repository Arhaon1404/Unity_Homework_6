using System.Collections;
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
    private int _count;

    private void Start()
    {
        _count = 0;
    }

    private void Update()
    {
        if (_count < _spawnCount)
        {
            RunCoroutine();
        }
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(_spawnSecondsPeriod);

        _newObject = Instantiate(_spawnableObject, transform.position, Quaternion.identity);

        _newObject.SetTarget(_target);

        _isDone = true;

        _count++;
    }

    private void RunCoroutine()
    {
        if (_isDone == true)
        {
            if (_spawnEnemyCoroutine != null)
            {
                StopCoroutine(_spawnEnemyCoroutine);
            }

            _isDone = false;
            _spawnEnemyCoroutine = StartCoroutine(SpawnObject());
        }
    }
}
