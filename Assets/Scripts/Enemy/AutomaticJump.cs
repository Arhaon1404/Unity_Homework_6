using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class AutomaticJump : DirectionTowarder
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _delay;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Coroutine _jumpCoroutine;
    private WaitForSeconds _jumpDelay;

    private bool _isDone = true;
    private string _jumpAnimation = "isJump";
    private string _fallAnimation = "isFall";
    private float _randomJumpValue;

    protected override void Start()
    {
        base.Start();

        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _randomJumpValue = Random.Range(-3f, 3f);
        _jumpDelay = new WaitForSeconds(_delay + _randomJumpValue);

        RunCoroutine();
    }

    protected override void Update()
    {
        base.Update();

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

    private IEnumerator Jump()
    {
        while (true)
        {
            _rigidbody.AddForce(Direction * (_jumpForce + _randomJumpValue), ForceMode2D.Impulse);

            yield return _jumpDelay;

            _isDone = true;
        }
    }

    private void RunCoroutine()
    {
        if (_isDone == true)
        {
            if (_jumpCoroutine != null)
            {
                StopCoroutine(_jumpCoroutine);
            }

            _isDone = false;
            _jumpCoroutine = StartCoroutine(Jump());
        }
    }
}
