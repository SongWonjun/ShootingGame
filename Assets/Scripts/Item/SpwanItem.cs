using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanItem : MonoBehaviour
{
    public static SpwanItem instance;
    public GameObject[] item;
    // public float magnetProbability;
    int itemIndex;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        itemIndex = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * 아이템 스폰 함수, 배열 길이 만큼 순회하면서 아이템 생성
     * 배열 인덱스가 끝까지 도달하면 인덱스를 초기화
     */
    public void SpwanItems(Transform tr)
    {
        if (itemIndex == item.Length)
        {
            itemIndex = 0;
        }
        Instantiate(item[itemIndex], tr.position, tr.rotation);
       
        itemIndex++;
        //print("ItemIndex:" + itemIndex);
    }
}
