using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float _rotSpeed = 200f;

    // ȸ�� �� ����
    float mx = 0;
    float my = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");    // ���� ȸ�� ��
        float mouseY = Input.GetAxis("Mouse Y");    // �¿� ȸ�� ��

        // ȸ�� �� ������ ���콺 �Է� ����ŭ �̸� ����
        mx += mouseX * _rotSpeed * Time.deltaTime;
        my += mouseY * _rotSpeed * Time.deltaTime;

        // ���콺 ���� �̵� ȸ�� ����(my)�� ���� -90 ~ 90�� ���̷� ����
        my = Mathf.Clamp(my, -90f, 90f);

        // ��ü�� ȸ�� �������� ȸ��
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
