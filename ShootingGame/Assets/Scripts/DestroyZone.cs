using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 충돌하는 즉시 충돌체 파괴
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if(other.gameObject.name.Contains("Bullet"))    // 부딪힌 물체가 총알일 경우
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();   // PlayerFire 클래스를 얻어오기
                player._bulletObjectPool.Add(other.gameObject);                             // 리스트에 총알 삽입
            }
        }
        else if(other.gameObject.name.Contains("Enemy"))    // 부딪힌 물체가 적일 경우
        {
            /*GameObject enemy = GameObject.Find("EnemyManager");             // EnemyManager 클래스 얻어오기
            EnemyManager manager = enemy.GetComponent<EnemyManager>();
            manager._enemyObjectPool.Add(other.gameObject);                 // 리스트에 Enemy 추가*/

            EnemyManager.Instance._enemyObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);          // 충돌한것이 Enemy, Bullet이 아니면 삭제
        }
    }
}
