using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DO_PRocket : MonoBehaviour
{
    public GameObject explosion;
    public GameObject radMis;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Do();
    }

    // 
    private void Do()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos = Vector2.up * Time.deltaTime * moveSpeed;
        transform.position = curPos + movePos;

        if (transform.position.y > 0.0f)
        {
            Explosion();
            SpawnRadMis();
            DestroyRocket();
        }
    }

    //
    void Explosion()
    {
        UiManager.instance.DeActiveRocketMissile();
        // 폭발 애니메이션 생성
        Instantiate(explosion, transform.position, transform.rotation);
    }

    // spawn rad mis
    void SpawnRadMis()
    {
        Instantiate(radMis, transform.position, transform.rotation);
    }

    // destroy
    private void DestroyRocket()
    {
        // 로켓 파괴 및 다시 쏠 수 있는 상태로 변경
        PRocket.instance.SetFireState(false); // false -> fire, true -> do not fire
        Destroy(gameObject);
    }
}
