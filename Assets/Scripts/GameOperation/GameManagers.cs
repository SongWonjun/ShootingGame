using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;
    public int coinScorePoint;
    private int score;
    private int distanceMeter;
    private bool gameFinFlag;
    public bool rocketMisssileExplosionState;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        GameInit();
    }

    void GameInit()
    {
        UiManager.instance.DeactiveGameOverText();
        UiManager.instance.DeActiveRocketMissile();
        SetRocketExplosionState(false);
        SetGameFinFlag(false);
    }

    public bool GetRocketExplosionState()
    {
        return rocketMisssileExplosionState;
    }

    public void SetRocketExplosionState(bool state)
    {
        rocketMisssileExplosionState = state;
    }

    public int GetCoinScorePoint()
    {
        return coinScorePoint;
    }

    public void SetCoinScorePoint(int point)
    {
        coinScorePoint = point;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetDistanceMeter()
    {
        return distanceMeter;
    }

    public void SetScore(int scorePoint)
    {
        score += scorePoint;
    }

    public void SetDistanceMeter(int distance)
    {
        distanceMeter += distance;
    }

    public bool GetGameFinFlag()
    {
        return gameFinFlag;
    }

    public void SetGameFinFlag(bool flag)
    {
        gameFinFlag = flag;
    }
}
