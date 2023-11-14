using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _moveSpeed = 7f;

    CharacterController cc;     // ĳ���� ��Ʈ�ѷ� ����
    float _gravity = -20f;      // �߷� ����
    float _yVelocity = 0;       // ���� �ӷ� ����

    public float _jumpPower = 10f;  // ������ ���� 
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

        // �̵� ���� ����(dir)�� ������ �Ǵ� ��ü ���� �������Գ� ������ ������ ����Ű�� ������ǥ�� �̵� �����̱� ������
        // �� �̵� ���͸� �����ǥ�� �̵� ���ͷ� ��ȯ�ϴ� �۾��� �ʿ��ϴ�.

        // ���� ī�޶� �������� ������ ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        // CollisionFlags�� Below�� ĳ���� ��Ʈ�ѷ��� �浹 ���� �� �Ʒ��� �κп� �浹���� �� true ���� ��ȯ�Ǹ�,
        // Above�� Side�� ���� ���ʰ� ���ʿ� �浹���� �� true ���� ��ȯ�ȴ�.

        // ���� �ٴڿ� ���� �ߴٸ�
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            if (_isJumping)
            {
                _isJumping = false;
                _yVelocity = 0;         // ĳ������ ���� �ӵ��� 0���� �����.
            }
        }

        if(Input.GetButtonDown("Jump") && !_isJumping)
        {
            _yVelocity = _jumpPower;    // ĳ���� ���� �ӵ��� �������� ����
            _isJumping = true;
        }

        // ĳ���� ���� �ӵ��� �߷� ���� ����
        _yVelocity += _gravity * Time.deltaTime;
        dir.y = _yVelocity;

        // �̵� �ӵ��� ���� �̵�
        cc.Move(dir * _moveSpeed * Time.deltaTime);
    }
}
