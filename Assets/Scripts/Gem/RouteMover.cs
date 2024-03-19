using UnityEngine;

public class RouteMover : MonoBehaviour
{
    [SerializeField] private TargetRoute _targetRoute;
    [SerializeField] private float _speed;

    private Vector3 _targetRouteCoordinate;
    private Vector3[] _targetRouteArray;

    private int _count;

    private void Start()
    {
        _targetRouteArray = new Vector3[_targetRoute.transform.childCount];

        for (int i = 0;i < _targetRoute.transform.childCount;i++)
        {
            _targetRouteArray[i] = _targetRoute.transform.GetChild(i).transform.position;
        }

        _count = 0;

        if (_targetRouteArray[_count] != null)
        {
            _targetRouteCoordinate = _targetRouteArray[_count];
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetRouteCoordinate, _speed * Time.deltaTime);

        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, _targetRouteCoordinate) == 0)
        {
            _targetRouteCoordinate = _targetRouteArray[_count++ % _targetRouteArray.Length];
        }
    }
}
