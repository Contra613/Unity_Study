using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _moveSpeed = 7f;

    CharacterController cc;     // 캐릭터 컨트롤러 변수
    float _gravity = -20f;      // 중력 변수
    float _yVelocity = 0;       // 수직 속력 변수

    public float _jumpPower = 10f;  // 점프력 변수 
    public bool _isJumping = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();    
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        // 이동 방향 벡터(dir)는 기준이 되는 주체 없이 누구에게나 동일한 방향을 가리키는 절대좌표의 이동 벡터이기 때문에
        // 이 이동 벡터를 상대좌표의 이동 벡터로 변환하는 작업이 필요하다.

        // 메인 카메라를 기준으로 방향을 변환
        dir = Camera.main.transform.TransformDirection(dir);

        // CollisionFlags의 Below는 캐릭터 컨트롤러의 충돌 영역 중 아래쪽 부분에 충돌했을 때 true 값이 반환되며,
        // Above와 Side는 각각 위쪽과 앞쪽에 충돌했을 때 true 값이 반환된다.

        // 만약 바닥에 착지 했다면
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            if (_isJumping)
            {
                _isJumping = false;
                _yVelocity = 0;         // 캐릭터의 수직 속도를 0으로 만든다.
            }
        }

        if(Input.GetButtonDown("Jump") && !_isJumping)
        {
            _yVelocity = _jumpPower;    // 캐릭터 수직 속도에 점프력을 적용
            _isJumping = true;
        }

        // 캐릭터 수직 속도에 중력 값을 적용
        _yVelocity += _gravity * Time.deltaTime;
        dir.y = _yVelocity;

        // 이동 속도에 맞춰 이동
        cc.Move(dir * _moveSpeed * Time.deltaTime);
    }
}
