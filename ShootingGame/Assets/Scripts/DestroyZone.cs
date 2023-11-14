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

    // �浹�ϴ� ��� �浹ü �ı�
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if(other.gameObject.name.Contains("Bullet"))    // �ε��� ��ü�� �Ѿ��� ���
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();   // PlayerFire Ŭ������ ������
                player._bulletObjectPool.Add(other.gameObject);                             // ����Ʈ�� �Ѿ� ����
            }
        }
        else if(other.gameObject.name.Contains("Enemy"))    // �ε��� ��ü�� ���� ���
        {
            /*GameObject enemy = GameObject.Find("EnemyManager");             // EnemyManager Ŭ���� ������
            EnemyManager manager = enemy.GetComponent<EnemyManager>();
            manager._enemyObjectPool.Add(other.gameObject);                 // ����Ʈ�� Enemy �߰�*/

            EnemyManager.Instance._enemyObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);          // �浹�Ѱ��� Enemy, Bullet�� �ƴϸ� ����
        }
    }
}
