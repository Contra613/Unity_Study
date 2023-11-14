using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int _poolSize = 10;          // 오브젝트 풀 크기
    public List<GameObject> _enemyObjectPool;      // 오브젝트 풀 리스트
    public Transform[] _spawnPoints;    // SpawnPoints들

    float _minTime = 0.5f;
    float _maxTime = 1.5f;

    float _currentTime;                         // 현제 시간
    public float _createTime;                   // 일정 시간
    public GameObject _enemyFactory;            // 적 생성 공장

    public static EnemyManager Instance = null;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _createTime = Random.Range(_minTime, _maxTime);
        _enemyObjectPool = new List<GameObject>();           // 오브젝트 풀을 Enemy를 담을 수 있는 크기로 설정

        for (int i = 0; i < _poolSize; i++)                     // 오브젝트 풀 개수만큼 반복
        {
            GameObject enemy = Instantiate(_enemyFactory);      // Enemy 생성
            _enemyObjectPool.Add(enemy);                        // Enemy를 오브젝트 풀에 삽입
            enemy.SetActive(false);                             // 비활성화
        }
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        
        if(_currentTime > _createTime)
        {
            if(_enemyObjectPool.Count > 0)  // 오브젝트 풀에 Enemy가 있다면 실행
            {
                GameObject enemy = _enemyObjectPool[0];                 // 오브젝트 풀에서 Enemy를 가져온다.
                _enemyObjectPool.Remove(enemy);                         // 오브젝트 풀에서 Enemy 삭제

                int index = Random.Range(0, _spawnPoints.Length);       // 랜덤 index 선택
                enemy.transform.position = transform.position;          // Enemy 위치 조정

                enemy.SetActive(true);                                  // Enemy 활성화
            }
            _currentTime = 0;                                   // 시간 초기화

            _createTime = Random.Range(_minTime, _maxTime);
        }
    }
}
