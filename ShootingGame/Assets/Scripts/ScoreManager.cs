using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;   // Unity UI 네임스페이스
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Text _currentScoreUI;    // 현제 점수 UI
    private int _currentScore;       // 현재 점수

    public Text _bestScoreUI;       // 최고 점수 UI
    private int _bestScore;          // 최고 점수

    public static ScoreManager Instance = null;    // 싱글턴 객체

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
        _bestScoreUI.text = " 최고 점수 : " + _bestScore;
    }

    void Update()
    {
        
    }

    public int Score
    {
        set
        {
            _currentScore = value;
            _currentScoreUI.text = "현제 점수 : " + _currentScore;

            if (_currentScore > _bestScore)        // 만약 현제 점수가 최고 점수라면..
            {
                _bestScore = _currentScore;
                _bestScoreUI.text = "최고 점수 : " + _bestScore;

                PlayerPrefs.SetInt("Best Score", _bestScore); // 최고 점수 저장
            }
        }
        get
        {
            return _currentScore;
        }
    }
}
