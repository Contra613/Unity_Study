using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5;
    void Start()
    {
                
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);

        // P = P0 + vt (미래 위치 = 현재 위치 + 속도 * 시간)
        transform.position += dir * _speed * Time.deltaTime;

    }
}
