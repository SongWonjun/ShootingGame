using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : Enemies
{

    public GameObject explosion;
    // Start is called before the first frame update
    protected override void Start()
    {
        hp = 6;
        destroyScorePoint = 3;
        moveSpeed = 5.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Fly();
    }

    protected override void Fly()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos = Vector2.down * Time.deltaTime * moveSpeed;

        transform.position = curPos + movePos;
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
