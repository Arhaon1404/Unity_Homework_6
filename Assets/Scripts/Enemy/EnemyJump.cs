using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpDelay;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Coroutine _jumpCoroutine;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _target;

    private bool _isDone = true;
    private string _jumpAnimation = "isJump";
    private string _fallAnimation = "isFall";

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float currentPositionX = transform.position.x;
        float currentPositionY = transform.position.y;

        _target = transform.GetComponent<Enemy>().target.transform.position;

        RunCoroutine();

        ChangeDirectionOfView(currentPositionX);
        ChangeJumpAnimation(currentPositionY);
    }

    private void ChangeJumpAnimation(float currentPositionY)
    {
        float changedPositionY = transform.position.y;

        if (currentPositionY < changedPositionY)
        {
            _animator.SetBool(_jumpAnimation,true);
            _animator.SetBool(_fallAnimation,false);
        }
        else if (currentPositionY > changedPositionY)
        {
            _animator.SetBool(_jumpAnimation, false);
            _animator.SetBool(_fallAnimation, true);
        }
        else
        {
            _animator.SetBool(_jumpAnimation, false);
            _animator.SetBool(_fallAnimation, false);
        }
    }

    private void ChangeDirectionOfView(float currentPositionX)
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

    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(_jumpDelay);

        Vector3 targetVector = _target - transform.position;

        targetVector = targetVector.normalized * _jumpForce;

        _rigidbody.AddForce(targetVector, ForceMode2D.Impulse);

        _isDone = true;
    }

    private void RunCoroutine()
    {
        if (_jumpCoroutine != null & _isDone == true)
        {
            StopCoroutine(_jumpCoroutine);
        }

        if (_isDone == true)
        {
            _isDone = false;
            _jumpCoroutine = StartCoroutine(Jump());
        }
    }
}
