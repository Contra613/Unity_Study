using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;   // Unity UI ���ӽ����̽�
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Text _currentScoreUI;    // ���� ���� UI
    private int _currentScore;       // ���� ����

    public Text _bestScoreUI;       // �ְ� ���� UI
    private int _bestScore;          // �ְ� ����

    public static ScoreManager Instance = null;    // �̱��� ��ü

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _bestScore = PlayerPrefs.GetInt("Best Score", 0);
        _bestScoreUI.text = " �ְ� ���� : " + _bestScore;
    }

    void Update()
    {
        
    }

    public int Score
    {
        set
        {
            _currentScore = value;
            _currentScoreUI.text = "���� ���� : " + _currentScore;

            if (_currentScore > _bestScore)        // ���� ���� ������ �ְ� �������..
            {
                _bestScore = _currentScore;
                _bestScoreUI.text = "�ְ� ���� : " + _bestScore;

                PlayerPrefs.SetInt("Best Score", _bestScore); // �ְ� ���� ����
            }
        }
        get
        {
            return _currentScore;
        }
    }
}
