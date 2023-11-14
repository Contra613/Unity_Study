using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 5;
    Vector3 dir;

    public GameObject explsionFactory;  // ���� ���� �ּ�
    void Start()
    {
        
    }

    void OnEnable()     // ��ü�� Ȱ��ȭ �ɶ����� ȣ��Ǵ� Ư¡
    {
        int randValue = UnityEngine.Random.Range(0, 10);    // 0 ~ 9 ���� ���� ����

        if (randValue > 3)   // ���� 3 �̻��̸� 
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

        GameObject explosion = Instantiate(explsionFactory);    // ���� ���忡�� ���� ȿ���� �ϳ� �����.
        explosion.transform.position = transform.position;      // ���� ȿ���� ��ġ ��Ų��.

        if(collision.gameObject.name.Contains("Bullet"))
        {
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();   // PlayerFire Ŭ���� ��������
            player._bulletObjectPool.Add(collision.gameObject);                         // ����Ʈ�� �Ѿ� ����
        }
        else
        {
            Destroy(collision.gameObject);          // �浹�Ѱ��� Enemy, Bullet�� �ƴϸ� ����
        }

        gameObject.SetActive(false);

        EnemyManager.Instance._enemyObjectPool.Add(gameObject);

        /*GameObject enemy = GameObject.Find("EnemyManager");
        EnemyManager manager = enemy.GetComponent<EnemyManager>();
        manager._enemyObjectPool.Add(gameObject);*/
    }
}
