using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    protected float shootTime = 0.0f;
    protected float attackDamage;
  
    protected virtual void OnShoot() { }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
