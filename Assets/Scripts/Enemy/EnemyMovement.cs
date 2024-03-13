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
        Vector3 target = transform.GetComponent<Enemy>().target.transform.position;

        var direction = target - transform.position;
        direction.Normalize();

        transform.position = Vector3.MoveTowards(transform.position, target, (_speed + _randomSpeedValue) * Time.deltaTime);

        ChangeMoveAnimation(direction.x);
    }

    private void ChangeMoveAnimation(float velocity)
    {
        switch (velocity)
        {
            case > 0:
                _spriteRenderer.flipX = true;
                break;
            case < 0:
                _spriteRenderer.flipX = false;
                break;
        }
    }
}
