using UnityEngine;

public class AutomaticMovement : DirectionTowarder
{
    [SerializeField] private float _speed;

    private float _randomSpeedValue;

    protected override void Start()
    {
        base.Start();

        _randomSpeedValue = Random.Range(-1f,1f);
    }

    protected override void Update()
    {
        base.Update();

        transform.position = Vector3.MoveTowards(transform.position, EnemyTarget.Target.transform.position, (_speed + _randomSpeedValue) * Time.deltaTime);
    }
}
