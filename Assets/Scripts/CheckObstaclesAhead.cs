using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class CheckObstaclesAhead : MonoBehaviour
{
    [SerializeField] private UnityEvent _touched;

    private const string _wall = "Wall";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wall) 
        {
            _touched.Invoke();
        }
    }
}
