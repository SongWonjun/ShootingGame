using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMissileController : MonoBehaviour
{
    public float rocketMissileShootTime;
    private bool rocketMissileShootLock;
    private bool rocketMissileUsingState;
    public static RocketMissileController instance;
    public GameObject rocketMissile;
    public Transform fireTr;

    // singleton 
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetRocketMissileShootLock(false);
        SetRocketMissileUsingState(false);
    }

    // 미사일 사용 여부 반환 
    public bool GetRocketMissileUsingState()
    {
        return rocketMissileUsingState;
    }

    // 미사일 사용 상태 설정
    public void SetRocketMissileUsingState(bool state)
    {
        rocketMissileUsingState = state;
    }


    // 락 상태 반환 
    public bool GetRocketMissileShootLock()
    {
        return rocketMissileShootLock;
    }

    // 락 상태 설정
    public void SetRocketMissileShootLock(bool state)
    {
        rocketMissileShootLock = state;
    }

    private void Update()
    {
        FiveSecondCount();
        RocketMissileSpwan();
    }

    void FiveSecondCount()
    {
        // 락이 걸려 있지 않은 상태에서만 5초를 카운팅
        if (!GetRocketMissileShootLock())
        {
            if (rocketMissileShootTime > 5.0f)
            {
                float remainder = rocketMissileShootTime - 5.0f;
                rocketMissileShootTime = 0;
                rocketMissileShootTime += remainder;
                UiManager.instance.ActiveRocketMissile(); // Rocket Missile image active
                SetRocketMissileShootLock(true); // 잠김
            }
            rocketMissileShootTime += Time.deltaTime;
        }
    }

    // 스페이스 키 누르고 유아이 활성화 되있는 상태에서만 로켓 미사일 생성
    void RocketMissileSpwan()
    {
        if(Input.GetKey(KeyCode.Space) && UiManager.instance.GetRocketMissileState())
        {
            Instantiate(rocketMissile, fireTr.position, rocketMissile.transform.rotation);
            UiManager.instance.SetRocketMissileState(false);
        }
    }
}
