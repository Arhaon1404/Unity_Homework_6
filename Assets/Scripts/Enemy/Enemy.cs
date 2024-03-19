using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Target _target;

    public Target Target => _target;

    public void SetTarget(Target target)
    { 
        _target = target;
    }
}
