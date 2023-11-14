using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject _bombeffect;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(_bombeffect);      // 이펙트 프리팹 생성
        eff.transform.position = transform.position;    // 이펙트의 위치는 수류탄의 위치와 동일하다.
        Destroy(gameObject);                            // 자신 삭제
    }
}
