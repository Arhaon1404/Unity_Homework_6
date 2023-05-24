using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticEnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime,0,0);
    }
}
