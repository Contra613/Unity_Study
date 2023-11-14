using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;    // 목표

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = target.position;   // 카메라 위치를 목표 Position에 위치
    }
}
