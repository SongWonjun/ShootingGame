using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    public void Shoot()
    {
        OnShoot();
    }

    protected override void OnShoot()
    {

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
        if (collision.gameObject.tag == "UpDestroyZone")
            Destroy(gameObject);
    }
}
