using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DO_EGreenMis : MonoBehaviour
{
    private Vector2 curPos;
    private Vector2 movePos;
    // Start is called before the first frame update
    void Start()
    {
        // 슈터 살아있는 경우
        if (Player.instance.gameObject.activeSelf)
            movePos = Player.instance.transform.position - transform.position;
        else // 슈터가 비활성화 된 경우, 랜덤 각도로 미사일 발사
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(90, 270)));
            movePos = transform.up;
        }
    }

    void Update()
    {
        Shoot();
    }

    // 생성되고 0.5초 후에 미사일 1발 슈터에게 발사
    void Shoot()
    {
        curPos = transform.position;
        movePos.Normalize();
        transform.position = curPos + movePos * Time.deltaTime * 8.0f;
    }
}
