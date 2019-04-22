using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMisOne : PlayerWeapon
{
    public GameObject missile;
    public Transform firePos;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // 미사일 1발 생성
    protected override void OnShoot()
    {
        if(shootTime > 0.05f)
        {
            Instantiate(missile, firePos.position, firePos.rotation);
            shootTime = 0.0f;
        }
        shootTime += Time.deltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
