using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shooter")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "DestroyZone")
        {
            Destroy(gameObject);
        }
    }
}
