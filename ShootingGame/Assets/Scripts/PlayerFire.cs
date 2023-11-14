using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    // �Ѿ� ���� ����
    public GameObject firePosition;     // �ѱ�

    public int _poolSize = 10;          // �Ѿ� 
    public List<GameObject> _bulletObjectPool;      // ������Ʈ Ǯ ����Ʈ

    /*
    �迭�� ����Ʈ�� ���̴� �迭�� ������Ʈ Ǯ�� ���� �����Ͽ� ��Ȱ��ȭ ��ü�� ã�Ҵٸ�,
    ����Ʈ���� ��Ȱ��ȭ ��ü�� ����ֱ� ������ �˻��� ���ʿ��ϴ�.
    */

    void Start()
    {
        //_bulletObjectPool = new GameObject[_poolSize];      // �Ѿ��� ���� �� �ִ� ũ�� ����
        _bulletObjectPool = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory); // �Ѿ� ����           
            _bulletObjectPool.Add(bullet);                  // �Ѿ��� ������Ʈ Ǯ�� ����
            bullet.SetActive(false);                        // ��Ȱ��ȭ
        }
    }

     void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(_bulletObjectPool.Count > 0)
            {
                GameObject bullet = _bulletObjectPool[0];
                bullet.SetActive(true);
                _bulletObjectPool.Remove(bullet);

                bullet.transform.position = firePosition.transform.position;
            }
        }
    }
}
