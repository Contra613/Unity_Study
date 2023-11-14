using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int _poolSize = 10;          // ������Ʈ Ǯ ũ��
    public List<GameObject> _enemyObjectPool;      // ������Ʈ Ǯ ����Ʈ
    public Transform[] _spawnPoints;    // SpawnPoints��

    float _minTime = 0.5f;
    float _maxTime = 1.5f;

    float _currentTime;                         // ���� �ð�
    public float _createTime;                   // ���� �ð�
    public GameObject _enemyFactory;            // �� ���� ����

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
        _enemyObjectPool = new List<GameObject>();           // ������Ʈ Ǯ�� Enemy�� ���� �� �ִ� ũ��� ����

        for (int i = 0; i < _poolSize; i++)                     // ������Ʈ Ǯ ������ŭ �ݺ�
        {
            GameObject enemy = Instantiate(_enemyFactory);      // Enemy ����
            _enemyObjectPool.Add(enemy);                        // Enemy�� ������Ʈ Ǯ�� ����
            enemy.SetActive(false);                             // ��Ȱ��ȭ
        }
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        
        if(_currentTime > _createTime)
        {
            if(_enemyObjectPool.Count > 0)  // ������Ʈ Ǯ�� Enemy�� �ִٸ� ����
            {
                GameObject enemy = _enemyObjectPool[0];                 // ������Ʈ Ǯ���� Enemy�� �����´�.
                _enemyObjectPool.Remove(enemy);                         // ������Ʈ Ǯ���� Enemy ����

                int index = Random.Range(0, _spawnPoints.Length);       // ���� index ����
                enemy.transform.position = transform.position;          // Enemy ��ġ ����

                enemy.SetActive(true);                                  // Enemy Ȱ��ȭ
            }
            _currentTime = 0;                                   // �ð� �ʱ�ȭ

            _createTime = Random.Range(_minTime, _maxTime);
        }
    }
}
