using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public Text distanceText;
    public Text scoreText;
    public Text gameOverText;
    public Image rocketMissile;
    public bool rocketMissileState;

    private Animator anim;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        anim = GameObject.Find("GameOverText").GetComponent<Animator>();
        SetRocketMissileState(false);
    }
    
    public void UpdateDistanceText()
    {
        distanceText.text = "Distance: " + GameManagers.instance.GetDistanceMeter() + "m";
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score:" + GameManagers.instance.GetScore() + " point";
    }

    // 게임 오버 텍스트 가져오기 
    public Text getGameOverText()
    {
        return gameOverText;
    }

    // 게임 오버 텍스트 활성화
    public void ActiveGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }

    // 게임 오버 텍스트 비활성화
    public void DeactiveGameOverText()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // 
    public void SetConditionGameOverTextAnim(bool flag)
    {
        Invoke("GameOverTextUpAnim", 2.0f);
    }

    // 
    void GameOverTextUpAnim()
    {
        anim.SetBool("TextUpTime", true);
    }

    // 로켓 미사일 이미지 활성화 비활성화 상태 반환
    public bool GetRocketMissileState()
    {
        return rocketMissileState;
    }

    // 로켓 미사일 이미지 상태 설정
    public void SetRocketMissileState(bool state)
    {
        rocketMissileState = state;
    }

    // 로켓 미사일 유아이 활성화
    public void ActiveRocketMissile()
    {
        rocketMissile.gameObject.SetActive(true);
        SetRocketMissileState(true);
    }

    // 로켓 미사일 유아이 비 활성화
    public void DeActiveRocketMissile()
    {
        rocketMissile.gameObject.SetActive(false);
        SetRocketMissileState(false);
    }
}
