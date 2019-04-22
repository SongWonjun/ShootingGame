using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMoveUp : MonoBehaviour
{
    Vector2 minBgPos;
    Vector2 maxBgPos;
    public float moveUpSpeed;
    public GameObject explosion;
    public GameObject radialMissile;

    // Start is called before the first frame update
    void Start()
    {
        minBgPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBgPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpRocketMissile();
    }

    // 기본적으로 위쪽 방향으로 이동
    // 화면 중간에 오면 폭발
    void MoveUpRocketMissile()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos = Vector2.up * Time.deltaTime * moveUpSpeed;
        transform.position = curPos + movePos;

        if(transform.position.y > 0.0f)
        {
            RocketMissileExplosion();
        }
    }

    // 로켓 터지면 유아이 비활성화
    // 로켓 터지는 애니메이션
    // 파괴
    void RocketMissileExplosion()
    {
        UiManager.instance.DeActiveRocketMissile();
        /*
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<EnemyController>().HitByMissileState();
        }
        */
        // 폭발 애니메이션 생성
        Instantiate(explosion, transform.position, transform.rotation);


        // 원형으로 미사일 쏘는 함수 호출 
        RadialMissileSpwan();

        // 로켓 파괴 및 잠금 해제
        RocketMissileController.instance.SetRocketMissileShootLock(false);
        Destroy(gameObject);
    }

    // 원형 형태로 미사일 발사
    void RadialMissileSpwan()
    {
        int degree = 30;
        Vector3 curRot = Vector3.zero;

        for (int i = 0; i < 12; i++)
        {

            Instantiate(radialMissile, transform.position, Quaternion.Euler(curRot));
            curRot.z += degree;
        }
    }
}
