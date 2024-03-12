using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _randomSpeedValue;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _randomSpeedValue = Random.Range(-1f,1f);
    }

    private void Update()
    {
        float currentPositionX = transform.position.x;

        Vector3 target = transform.GetComponent<Enemy>().target.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, target, (_speed + _randomSpeedValue) * Time.deltaTime);

        ChangeMoveAnimation(currentPositionX);
    }

    private void ChangeMoveAnimation(float currentPositionX)
    {
        float changedPositionX = transform.position.x;

        if (currentPositionX < changedPositionX)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
