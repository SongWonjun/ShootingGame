using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : Enemies
{

    public GameObject explosion;
    // Start is called before the first frame update
    protected override void Start()
    {
        hp = 8;
        destroyScorePoint = 4;
        moveSpeed = 3.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Fly();
    }

    // move
    protected override void Fly()
    {
        Vector2 curPos = transform.position;
        Vector2 moveDir = Vector2.down * Time.deltaTime * moveSpeed;
        transform.position = curPos + moveDir;

        if (MoveShooter.instance.gameObject.activeSelf)
        {
            curPos = transform.position;
            moveDir = MoveShooter.instance.transform.position - transform.position;
            moveDir.Normalize();
            transform.position = curPos + moveDir * Time.deltaTime * moveSpeed;
        }
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
        SpwanItem.instance.SpwanItems(transform);
        GameManagers.instance.SetScore(destroyScorePoint);
        UiManager.instance.UpdateScoreText();
        Instantiate(explosion, transform.position, transform.rotation);
    }

}
