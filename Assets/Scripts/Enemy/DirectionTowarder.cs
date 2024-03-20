using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Enemy))]

public class DirectionTowarder : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    protected Enemy EnemyTarget;
    protected Vector3 Direction;

    protected virtual void Start()
    {
        EnemyTarget = transform.GetComponent<Enemy>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        Direction = EnemyTarget.Target.transform.position - transform.position;
        Direction.Normalize();

        _spriteRenderer.flipX = Direction.x > 0f;
    }
}
