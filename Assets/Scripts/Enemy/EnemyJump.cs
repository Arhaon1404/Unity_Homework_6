using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class EnemyJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpDelay;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Coroutine _jumpCoroutine;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _direction;

    private bool _isDone = true;
    private string _jumpAnimation = "isJump";
    private string _fallAnimation = "isFall";
    private float _randomJumpForceValue;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _randomJumpForceValue = Random.Range(-3f, 3f);
    }

    private void Update()
    {
        _direction = transform.GetComponent<Enemy>().target.transform.position - transform.position;
        _direction.Normalize();

        RunCoroutine();

        ChangeDirectionOfView(_direction.x);
        ChangeJumpAnimation(_rigidbody.velocity.y);
    }

    private void ChangeJumpAnimation(float velocityY)
    {
        if (velocityY > 0)
        {
            _animator.SetBool(_jumpAnimation,true);
            _animator.SetBool(_fallAnimation,false);
        }
        else if (velocityY < 0)
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

    private void ChangeDirectionOfView(float velocityX)
    {
        switch (velocityX)
        {
            case > 0:
                _spriteRenderer.flipX = true;
                break;
            case < 0:
                _spriteRenderer.flipX = false;
                break;
        }
    }

    private IEnumerator Jump()
    {
        while (true)
        {
            _rigidbody.AddForce(_direction * (_jumpForce + _randomJumpForceValue), ForceMode2D.Impulse);

            yield return new WaitForSeconds(_jumpDelay);

            _isDone = true;
        }
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
