using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : Enemies
{
    public Transform[] wayPoints; // way point 
    public GameObject missile;
    public GameObject explosion;
    private int wayPointsIndex;
   
    // Start is called before the first frame update
    protected override void Start()
    {
        hp = 9;
        destroyScorePoint = 5;
        moveSpeed = 5.0f;

        GameObject wayPoint = GameObject.FindGameObjectWithTag("WayPoints"); // WayPoints 태그 갖고 있는 오브젝트 찾기
        wayPoints = wayPoint.GetComponentsInChildren<Transform>(); // 자식 오브젝트
        wayPointsIndex = 0;

        Invoke("Fire", 1.0f);
    }

    // fire
    private void Fire()
    {
        Instantiate(missile, transform.position, transform.rotation);
    }

    // Update is called once per frame
    protected override void Update()
    {
        Fly();
    }

    // move
    protected override void Fly()
    {
        Vector2 moveDir = wayPoints[wayPointsIndex + 1].transform.position - transform.position;

        if (Vector2.SqrMagnitude(moveDir) < 0.2f)
            wayPointsIndex++;

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPointsIndex + 1].transform.position, Time.deltaTime * 5);
    }

    // trigger
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.tag == "Missile")
        {
            hp -= 3;
            if (hp < 0)
                EnemyDestroy();
        }
    }

    // destroy enemy
    private void EnemyDestroy()
    {
        Destroy(gameObject);
        ItemManager.instance.SpwanItems(transform);
        GameManagers.instance.SetScore(destroyScorePoint);
        UiManager.instance.UpdateScoreText();
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
