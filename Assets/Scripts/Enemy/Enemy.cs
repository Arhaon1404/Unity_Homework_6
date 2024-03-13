using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Target _target;

    public Target target => _target;

    public void GetTarget(Target target)
    { 
        _target = target;
    }
}
