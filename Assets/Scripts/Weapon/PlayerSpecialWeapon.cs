using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialWeapon : Weapon
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

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
