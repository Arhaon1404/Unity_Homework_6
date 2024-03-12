using UnityEngine;

public class RouteMover : MonoBehaviour
{
    [SerializeField] private Target _movebleObject;
    [SerializeField] private TargetRoute _targetRoute;
    [SerializeField] private float _speed;

    private Vector3 _targetRouteCoordinate;
    private int _counter;

    private void Start()
    {
        _counter = 0;

        if (_targetRoute.transform.GetChild(_counter) != null)
        {
            _targetRouteCoordinate = _targetRoute.transform.GetChild(_counter).transform.position;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetRouteCoordinate, _speed * Time.deltaTime);

        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, _targetRouteCoordinate) <= 0)
        {
            int arrayCounter = _counter + 1;

            if (arrayCounter < _targetRoute.transform.childCount)
            {
                _targetRouteCoordinate = _targetRoute.transform.GetChild(_counter).transform.position;
                _counter++;
            }
            else
            {
                _targetRouteCoordinate = _targetRoute.transform.GetChild(_counter).transform.position;
                _counter = 0;
            }
        }
    }
}
