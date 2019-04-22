using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMis : EnemyWeapon
{
    public GameObject missile;
    public Transform firePos;

    // Start is called before the first frame update
    protected override void Start()
    {
        shootTime = 0.2f;   
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    // spawn
    protected override void OnShoot()
    {
        StartCoroutine("Fire");
    }

    // fire
    IEnumerator Fire()
    {
        for(int i = 0; i < 3; i++)
        {
            Instantiate(missile, firePos.position, firePos.rotation);
            yield return new WaitForSeconds(shootTime); // 0.2 period
        }
    }

    // trigger
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
