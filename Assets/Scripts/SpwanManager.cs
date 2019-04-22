using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpwanManager : MonoBehaviour
{

    [System.Serializable]
    public class EnemySpwanData
    {
        public float appearanceTime; // 첫 등장 시간 
        public float appearCount; // 생성되는 개수
        public float intervals; // 웨이브 안에서 생성 주기 
        public string spwanKind; // 생성 종류
        public float spwanPosX; // 생성 위치
        public float spwanPosY; // 생성 위치
        public float stopSpawnTime; // 생성 멈추는 시간
        public int stopFlag; // 생성 여부 플래그
    }

    private float gamePlayTime = 0.0f; // 게임 시간 
    private float stopSpawnTime = 240.0f; // 적기 생성 멈춰지는 시간

    private EnemySpwanData[] enemyData;
    private int enemyDataIdx; // 배열 인덱스 
    private float arrRotTime; // 적기 생성 주기 시간

    public GameObject[] enemyObject;
    private Vector2 minBgPos;
    private Vector2 maxBgPos;

    // Start is called before the first frame update
    void Start()
    {
        string jsonData = File.ReadAllText(UnityEngine.Application.dataPath + "/Json/spwanData.json"); // json 파일 read
        enemyData = JsonHelper.FromJson<EnemySpwanData>(jsonData); // json 파일 -> 메모리에 write

        minBgPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBgPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        enemyDataIdx = 0;
        arrRotTime = 2.0f;
        // lastIdx = enemyData.Length -1;
        // print("Last Idx :" + lastIdx);
    }

    // Update is called once per frame
    void Update()
    {
        Play();
    }

    private void Play()
    {
        // 인덱스 순환 
        if (enemyDataIdx > enemyData.Length - 1) enemyDataIdx = 0;

        gamePlayTime += Time.deltaTime;

        // 4분 동안 적기들 생성
        if (gamePlayTime < stopSpawnTime && MoveShooter.instance.gameObject.activeSelf)
        {
            if(gamePlayTime >= enemyData[enemyDataIdx].appearanceTime) // 기본 적기 생성
            {
                if(enemyData[enemyDataIdx].stopFlag != 1)
                    StartCoroutine("SpwanObject", enemyDataIdx); // 코루틴 호출

                enemyData[enemyDataIdx].appearanceTime += arrRotTime;

                if (enemyData[enemyDataIdx].stopSpawnTime < gamePlayTime)
                    enemyData[enemyDataIdx].stopFlag = 1;

                print("gamePlayTime:" + gamePlayTime + ", " + "EnmeyDataIdx:" + enemyDataIdx + "enemyDataAppearanceTime: " + enemyData[enemyDataIdx].appearanceTime);
                enemyDataIdx++;
            }
        }
    }

    IEnumerator SpwanObject(int idx)
    {
        Vector2 curPos = new Vector2(enemyData[idx].spwanPosX, enemyData[idx].spwanPosY);
        Vector2 ranPos;
        GameObject retObject;

        for(int i = 0; i < enemyData[idx].appearCount; i++) // 한 번 호출 시 생성하는 적기 개수
        {
            if(enemyData[idx].spwanKind.Equals("patternLtoR")) // 패턴으로 나오는 적기일 경우 생성 위치 랜덤으로 잡을 필요 없음 
            {
                // print("spawn pos:" + curPos);
                retObject = Instantiate(enemyObject[idx], curPos, transform.rotation);
                // retObject.transform.parent = gameObject.transform; // 부모 오브젝트 지정
            }
            else
            {
                ranPos = new Vector2(Random.Range(minBgPos.x + 1, maxBgPos.x), curPos.y);
                retObject = Instantiate(enemyObject[idx], curPos + ranPos, transform.rotation);
                retObject.transform.parent = gameObject.transform; // 부모 오브젝트 지정
            }
            yield return new WaitForSeconds(enemyData[idx].intervals); 
        }
    }
}

