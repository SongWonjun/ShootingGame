using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected int hp;
    protected int destroyScorePoint;
    protected float moveSpeed;
    
    // trigger 
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyZone")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Shooter")
        {
            Destroy(gameObject);
        }

        /*
        if (collision.gameObject.tag == "Missile")
        {
            hp -= 3;
            if (hp < 0)
            {
                AfterEnemyDeathEvent();
            }
        }
        */
    }
    // move
    protected virtual void Fly() { }

    // missile shoot
    protected virtual void Shoot() { }

    // Start is called before the first frame update
    protected virtual void Start(){}

    // Update is called once per frame
    protected virtual void Update() {}
}
