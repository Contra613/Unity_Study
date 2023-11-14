using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 5;
    Vector3 dir;

    public GameObject explsionFactory;  // 폭발 공장 주소
    void Start()
    {
        
    }

    void OnEnable()     // 객체가 활성화 될때마다 호출되는 특징
    {
        int randValue = UnityEngine.Random.Range(0, 10);    // 0 ~ 9 숫자 랜덤 추출

        if (randValue > 3)   // 값이 3 이상이면 
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explsionFactory);    // 폭발 공장에서 폭발 효과를 하나 만든다.
        explosion.transform.position = transform.position;      // 폭발 효과를 위치 시킨다.

        if(collision.gameObject.name.Contains("Bullet"))
        {
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();   // PlayerFire 클래스 가져오기
            player._bulletObjectPool.Add(collision.gameObject);                         // 리스트에 총알 삽입
        }
        else
        {
            Destroy(collision.gameObject);          // 충돌한것이 Enemy, Bullet이 아니면 삭제
        }

        gameObject.SetActive(false);

        EnemyManager.Instance._enemyObjectPool.Add(gameObject);

        /*GameObject enemy = GameObject.Find("EnemyManager");
        EnemyManager manager = enemy.GetComponent<EnemyManager>();
        manager._enemyObjectPool.Add(gameObject);*/
    }
}
