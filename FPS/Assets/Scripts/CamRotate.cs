using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float _rotSpeed = 200f;

    // 회전 값 변수
    float mx = 0;
    float my = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");    // 상하 회전 값
        float mouseY = Input.GetAxis("Mouse Y");    // 좌우 회전 값

        // 회전 값 변수에 마우스 입력 값만큼 미리 누적
        mx += mouseX * _rotSpeed * Time.deltaTime;
        my += mouseY * _rotSpeed * Time.deltaTime;

        // 마우스 상하 이동 회전 변수(my)의 값을 -90 ~ 90도 사이로 제한
        my = Mathf.Clamp(my, -90f, 90f);

        // 물체를 회전 방향으로 회전
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
