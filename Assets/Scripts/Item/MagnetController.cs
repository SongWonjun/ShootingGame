using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    // 슈터와 디스트로이 존에 부딪혔을 때 파괴
    // 현재는 마그넷 아이템 생성하지 않음, 무조건 슈터가 코인 수급하도록 되어 있음 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shooter")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "DestroyZone")
        {
            Destroy(gameObject);
        }
    }
    
}
