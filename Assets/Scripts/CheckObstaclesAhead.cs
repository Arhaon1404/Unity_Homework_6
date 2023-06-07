using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class CheckObstaclesAhead : MonoBehaviour
{
    [SerializeField] private UnityEvent _touched;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Wall wall)) 
        {
            _touched.Invoke();
        }
    }
}
