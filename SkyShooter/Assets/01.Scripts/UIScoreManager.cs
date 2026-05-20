using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreManager : MonoBehaviour
{
    // 싱글톤 
    // 하나의 객체만 존재, static 영역에 생성
    
    public static UIScoreManager instance = null;
    
    public int score = 0;
    public Text scoreText;
    private void Awake()
    {
        if(instance == null) instance = this;
    }

    private void Start()
    {
        SetScore();
    }

    public void SetScore()
    {
        scoreText.text = $"Score: {score.ToString()}";
    }
}
