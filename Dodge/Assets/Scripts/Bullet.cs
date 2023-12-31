using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;      //  이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;                // 이동 속력

    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디 속도 = 앞쪽 방행 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f); 
    }

    // - 모두 Collider과 관련된 코드들 (충돌)
    // OnTriggerEnter : 충돌하면 실행
    // OnTriggerStay : 충돌 유지
    // OnTriggerExit : 충돌 시 통과 가능 (충돌은 체크된다.)
    private void OnTriggerEnter(Collider other) 
    {
        // 충돌한 상대방 게임 오브젝트가 Player인 경우
        if(other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerCntroller 컴포넌트 가져오기 
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController을 가져오는데 성공했다면
            if(playerController != null)
            {
                // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
