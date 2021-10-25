using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 1.0f;
    private bool _forward = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }
    void CalculateMovement()
    {
        {
            if (_forward == true && transform.position.x < 25)
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
            else if (_forward == true && transform.position.x >= 25)
            {
                _forward = false;
            }
            if (_forward == false && transform.position.x > -9)
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            else if (_forward == false && transform.position.x <= -9)
            {
                _forward = true;
            }

        }
    }
}