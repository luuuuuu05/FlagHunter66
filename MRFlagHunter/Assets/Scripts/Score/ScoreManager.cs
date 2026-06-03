using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int value)
    {
        Score += value;

        Debug.Log("当前分数：" + Score);
    }
}
