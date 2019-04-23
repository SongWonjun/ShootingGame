using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator exPlosionAnimator;
    // Start is called before the first frame update
    void Start()
    {
        exPlosionAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyExplosion();
    }

    void DestroyExplosion()
    {
        // print("1");
        if (exPlosionAnimator.GetCurrentAnimatorStateInfo(0).IsName("ExPlosionAnim"))
        {
            // print("2");
            if (exPlosionAnimator.GetCurrentAnimatorStateInfo(0).length < exPlosionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime)
            {
                 Destroy(gameObject);
            }
        }
    }
}
