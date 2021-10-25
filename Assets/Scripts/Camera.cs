using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        this.transform.position = new Vector3(_player.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
