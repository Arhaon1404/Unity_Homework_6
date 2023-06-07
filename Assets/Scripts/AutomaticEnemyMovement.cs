using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class AutomaticEnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private SpriteRenderer _spriteRenderer;

    private float _direction = -1f;
    private bool _isLeft = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(_speed * (Time.deltaTime * _direction),0,0);
    }

    public void ChangeDirection()
    {
        if (_isLeft == true)
        {
            _direction = 1f;

            _spriteRenderer.flipX = true;

            _isLeft = false;
        }
        else
        {
            _direction = -1f;

            _spriteRenderer.flipX = false;

            _isLeft = true;
        }
    }
}
