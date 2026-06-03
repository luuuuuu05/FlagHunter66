using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private ResultPanel resultPanel;
    [SerializeField] private float gameDuration = 60f;

    public bool IsPlaying { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameTimer.OnTimeUp += EndGame;
        StartGame();
    }

    public void StartGame()
    {
        IsPlaying = true;
        ScoreManager.Instance.ResetScore();
        gameTimer.StartTimer(gameDuration);
        resultPanel.Hide();
    }

    public void EndGame()
    {
        IsPlaying = false;
        resultPanel.Show(ScoreManager.Instance.Score);
    }
}
