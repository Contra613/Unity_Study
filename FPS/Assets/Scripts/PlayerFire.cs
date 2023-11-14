using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject _Bomb;            
    public GameObject _firePosition;

    public float _throwPower = 15f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(_Bomb);
            bomb.transform.position = _firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            // 카메라 정면 방향으로 수류탄의 물리적인 힘을 가한다.
            rb.AddForce(Camera.main.transform.forward * _throwPower, ForceMode.Impulse);    
        }
    }
}
