using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _spawnableObject;
    [SerializeField] private float _spawnSecondsDelay;
    [SerializeField] private int _spawnCount;

    private Enemy _newObject;
    private Coroutine _spawnEnemyCoroutine;
    private WaitForSeconds _spawnDelay;
    private bool _isDone = true;

    private void Start()
    {
        _spawnDelay = new WaitForSeconds(_spawnCount);

        RunCoroutine();
    }

    private IEnumerator SpawnObject()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            yield return _spawnDelay;

            _newObject = Instantiate(_spawnableObject, transform.position, Quaternion.identity);

            _newObject.SetTarget(_target);
        }

        _isDone = true;
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
