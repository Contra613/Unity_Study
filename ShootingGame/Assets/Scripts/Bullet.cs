using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed = 5;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 dir = Vector3.up;                                   // �̵� ����
        transform.position += dir *_speed * Time.deltaTime;         // �̵� ��ġ
    }
}
