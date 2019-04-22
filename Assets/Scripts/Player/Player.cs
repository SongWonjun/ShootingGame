using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float shooterMoveSpeed;
    // public float rocketMissileOnTime;
    // private SpwanEnemy spwanScript;
    private Vector2 minBgPos;
    private Vector2 maxBgPos;
   
    public EnemyWeapon[] myWeapon;
    private EnemyWeapon curWeapon;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        minBgPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBgPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        curWeapon = myWeapon[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ShootMissile();
    }

    // 슈터 이동(키보드 입력)
    void Move()
    {
        Vector2 curPos = transform.position;
        Vector2 movePos;  

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movePos = Vector2.right * Time.deltaTime * shooterMoveSpeed;
            transform.position = curPos + movePos;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            movePos = Vector2.left * Time.deltaTime * shooterMoveSpeed;
            transform.position = curPos + movePos;
        }

        if (transform.position.x < minBgPos.x || transform.position.x > maxBgPos.x)
            transform.position = curPos;
    }

    // Q를 누르면 1발 미사일, W 누르면 3발 미사일 발사
    void ShootMissile()
    {
        if (Input.GetKey(KeyCode.Q))
            curWeapon = myWeapon[0];
        else if (Input.GetKey(KeyCode.W))
            curWeapon = myWeapon[1];

        curWeapon.Shoot();
    }
    
    //코인과 충돌 처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Destroy(gameObject);
            Destroy(collision.gameObject);
            GameManagers.instance.SetGameFinFlag(true);
            UiManager.instance.ActiveGameOverText();
            UiManager.instance.SetConditionGameOverTextAnim(true);
            gameObject.SetActive(false); // 슈터 비활성화
        }

        if(collision.gameObject.tag == "Missile")
        {
            GameManagers.instance.SetGameFinFlag(true);
            UiManager.instance.ActiveGameOverText();
            UiManager.instance.SetConditionGameOverTextAnim(true);
            gameObject.SetActive(false); // 슈터 비활성화
        }
    }

}
