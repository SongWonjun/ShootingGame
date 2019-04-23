using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    // Start is called before the first frame update
    protected override void Start()
    {
        moveSpeed = 3.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Do();
    }

    // move down
    protected override void Do()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos = Vector2.down * Time.deltaTime * moveSpeed;

        transform.position = curPos + movePos;
    }

    // trigger check
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
