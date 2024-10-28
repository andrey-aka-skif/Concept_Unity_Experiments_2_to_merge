using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMoverComponent : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _speed * Vector3.left * Time.deltaTime;
    }
}
