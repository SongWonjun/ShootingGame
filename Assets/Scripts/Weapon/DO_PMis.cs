using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DO_PMis : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Do();   
    }

    private void Do()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos = transform.up * Time.deltaTime * moveSpeed;

        transform.position = curPos + movePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UpDestroyZone")
            Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
