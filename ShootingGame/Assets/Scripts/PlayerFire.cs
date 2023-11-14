using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    // 총알 생성 공장
    public GameObject firePosition;     // 총구

    public int _poolSize = 10;          // 총알 
    public List<GameObject> _bulletObjectPool;      // 오브젝트 풀 리스트

    /*
    배열과 리스트의 차이는 배열은 오브젝트 풀을 전수 조사하여 비활성화 객체를 찾았다면,
    리스트에는 비활성화 객체만 들어있기 때문에 검색이 불필요하다.
    */

    void Start()
    {
        //_bulletObjectPool = new GameObject[_poolSize];      // 총알을 담을 수 있는 크기 설정
        _bulletObjectPool = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory); // 총알 생성           
            _bulletObjectPool.Add(bullet);                  // 총알을 오브젝트 풀에 삽입
            bullet.SetActive(false);                        // 비활성화
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
