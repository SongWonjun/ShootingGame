using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{

    public static SpwanEnemy instance;
    public GameObject enemy;
    public GameObject selfDestructEnemy;
    public float spwanTime;
    [HideInInspector] public bool spwanFlag;
    public float selfEploitProbability;

    private Vector2 minBgPos;
    private Vector2 maxBgPos;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSpwanFlag(true);
        minBgPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBgPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public bool GetSpwanFlag()
    {
        return spwanFlag;
    }

    public void SetSpwanFlag(bool flag)
    {
        spwanFlag = flag;
    }

    // Update is called once per frame
    void Update()
    {
        SpwanSystem();
    }
    
    void SpwanSystem()
    {
        if(spwanFlag)
        {
            if(spwanTime < 0f)
            {
                Spwan();
                spwanTime = 0.2f;
            }
            spwanTime -= Time.deltaTime;
        }
    }

    // 적기 스폰
    // 0.9 이상일 때만 자폭 비행기 생성
    // 
    void Spwan()
    {
        GameObject enemysTemp;
        Vector2 randomPos = new Vector2(Random.Range(minBgPos.x + 1, maxBgPos.x), transform.position.y);

        if (Random.value > selfEploitProbability)
        {
            enemysTemp = Instantiate(selfDestructEnemy, randomPos, transform.rotation);
        }
        else
        {
            enemysTemp = Instantiate(enemy, randomPos, transform.rotation);
        }
        enemysTemp.transform.parent = gameObject.transform;  // EnemySpwanPos 오브젝트의 자식으로 설정
    }
}
