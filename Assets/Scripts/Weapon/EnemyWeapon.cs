using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Weapon
{

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public void Shoot()
    {
        OnShoot();
    }

    protected override void OnShoot()
    {

    }

    // trigger
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shooter")
            Destroy(gameObject);
        if (collision.gameObject.tag == "DestroyZone")
            Destroy(gameObject);
    }
}
