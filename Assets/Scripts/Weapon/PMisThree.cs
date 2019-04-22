using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMisThree : PlayerWeapon
{

    public GameObject missile;
    public Transform firePos;
    public Vector3[] rot;
    // Start is called before the first frame update
    protected override void Start()
    {
       
    }

    // 미사일 3발 생성
    protected override void OnShoot()
    {
        if(shootTime > 0.05f)
        {
            Instantiate(missile, firePos.position, Quaternion.Euler(rot[0]));
            Instantiate(missile, firePos.position, Quaternion.Euler(rot[1]));
            Instantiate(missile, firePos.position, Quaternion.Euler(rot[2]));
            shootTime = 0.0f;
        }
        shootTime += Time.deltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
