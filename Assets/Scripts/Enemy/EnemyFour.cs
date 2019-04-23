using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFour : Enemies
{
    public GameObject explosion;
    public GameObject missile;

    private float stopPosY;
    private Transform shootPos;

    // Start is called before the first frame update
    protected override void Start()
    {
        hp = 10;
        destroyScorePoint = 6;
        moveSpeed = 5.0f;

        stopPosY = 1.5f;

        shootPos = transform.GetChild(0);

        StartCoroutine("MoveDown");
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    protected override void Shoot()
    {
        
    }

    private void MoveDown()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos = Vector2.down * Time.deltaTime * 3.0f;
        transform.position = curPos + movePos;

        if (transform.position.y < stopPosY)
            StartCoroutine("Stop");
    }

    private void Stop()
    {
        for (int i = 0; i < 2; i++)
            Invoke("SpawnMissile", 0.0f);
        StartCoroutine("MoveUp");
    } 

    private void MoveUp()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos = Vector2.up * Time.deltaTime * 3.0f;
        transform.position = curPos + movePos;
    }

    private void SpawnMissile()
    {
        Instantiate(missile, shootPos.position, shootPos.rotation);
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
