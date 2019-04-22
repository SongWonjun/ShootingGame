using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoveDown : MonoBehaviour
{

    public float backGroundFinalMoveSpeed;
    public float backGroundMiddleMoveSpeed;
    public float backGroundFrontMoveSpeed;

    public Transform finalBg;
    public Transform middleBg;
    public Transform frontBg;

    private Vector3 minBgPos;
    private Vector3 maxBgPos;
    private float bgSize;

    public int standardMoveDistance;

    // Start is called before the first frame update
    void Start()
    {
        minBgPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        maxBgPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        bgSize = (maxBgPos.y - minBgPos.y) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        BackGroundMoveDownSpeedFinal(backGroundFinalMoveSpeed);
        BackGroundMoveDownSpeedMiddle(backGroundMiddleMoveSpeed);
        BackGroundMoveDownSpeedFront(backGroundFrontMoveSpeed);
    }

    // 가장 뒷 배경 움직이는 함수
    void BackGroundMoveDownSpeedFinal(float bgMoveSpeed)
    {
        Vector2 curPos = finalBg.position;
        Vector2 newPos = Vector2.down * Time.deltaTime * bgMoveSpeed;

        finalBg.position = curPos + newPos;
        if (finalBg.position.y < bgSize * -1) finalBg.position = Vector2.zero;
    }

    // 가운데 배경 움직이는 함수
    void BackGroundMoveDownSpeedMiddle(float bgMoveSpeed)
    {
        Vector2 curPos = middleBg.position;
        Vector2 newPos = Vector2.down * Time.deltaTime * bgMoveSpeed;

        middleBg.position = curPos + newPos;
        if (middleBg.position.y < bgSize * -1) middleBg.position = Vector2.zero;
    }

    // 앞에 있는 배경 움직이는 함수
    void BackGroundMoveDownSpeedFront(float bgMoveSpeed)
    {
        Vector2 curPos = frontBg.position;
        Vector2 newPos = Vector2.down * Time.deltaTime * bgMoveSpeed;

        frontBg.position = curPos + newPos;
        if (frontBg.position.y < bgSize * -1)
        {
            frontBg.position = Vector2.zero;
            //
            if(!GameManagers.instance.GetGameFinFlag())
            {
                GameManagers.instance.SetDistanceMeter(standardMoveDistance);
                UiManager.instance.UpdateDistanceText();
            }
           
        }
    }

}
