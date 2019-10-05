using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float score;
    public int distanceTravelled;

    public static Action OnGameStart;
    public static Action OnGameEnd;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
    }

    public void EndGame()
    {
        OnGameStart?.Invoke();
    }

    //[POLISH] reset game function later if time... no point wasting time.. reset scene instead

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }
}
