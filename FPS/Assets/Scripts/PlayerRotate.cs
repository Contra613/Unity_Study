using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float _rotSpeed = 200f;
    float mx = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // Player�� �¿� ȸ���� ����
        float mouseX = Input.GetAxis("Mouse X");
        mx += mouseX * _rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
