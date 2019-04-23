using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRocket : PlayerSpecialWeapon
{
    public static PRocket instance;
    public GameObject missile;
    public Transform firePos;
    private bool fireState;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        fireState = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    // rocket missile fire
    protected override void OnShoot()
    {
        if(shootTime > 5.0f && !fireState && Input.GetKey(KeyCode.Space))
        {
            Instantiate(missile, firePos.position, firePos.rotation);
            fireState = true;
            shootTime = 0.0f;
        }

        shootTime += Time.deltaTime;
    }

    // setting fire state
    public void SetFireState(bool _fireState)
    {
        fireState = _fireState;
    }
}
