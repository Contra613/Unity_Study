using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;    // ��ǥ

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = target.position;   // ī�޶� ��ġ�� ��ǥ Position�� ��ġ
    }
}
