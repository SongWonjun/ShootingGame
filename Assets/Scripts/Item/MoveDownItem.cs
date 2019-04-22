using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownItem : MonoBehaviour
{
    public float moveDownSpeed;
    public float range;
    private float speedUp = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ItemDown();
    }

    // 아이템이 아래로 이동하게 하는 함수
    // 일정 거리 안에 슈터가 들어오면 슈터 쪽으로 이동하는 함수
    void ItemDown()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos = Vector2.down * Time.deltaTime * moveDownSpeed;
        transform.position = curPos + movePos;

        if(MoveShooter.instance.gameObject.activeSelf)
        {
            float dis = Vector2.SqrMagnitude(transform.position - MoveShooter.instance.transform.position);

            if (dis < range && MoveShooter.instance.gameObject.activeSelf)
            {
                curPos = transform.position;
                Vector2 moveDir = MoveShooter.instance.transform.position - transform.position;
                moveDir.Normalize();
                transform.position = curPos + moveDir * Time.deltaTime * moveDownSpeed * speedUp;
            }
        }
       
    }
}
