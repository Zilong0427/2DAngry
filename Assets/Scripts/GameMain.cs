using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{

    public GameObject Camera;
    public GameObject StonePrefab;
    [Header("產生球的位置")]
    public Transform InsPosition;
    [Header("產生球時把彈弓的兩點給予球")]
    public Transform LinePoint1;
    public Transform LinePoint2;

    public bool IsWin;


    private GameObject _Stone;
    //可以使用的石頭數量，超過還沒打到小鳥就輸了
    private int _StoneNum = 3;
    // Use this for initialization
    void Start()
    {
        Init();
    }
    void Init()
    {
        _StoneNum = 3;
        InsNewStone();
    }
    public void InsNewStone()
    {
        _Stone = (GameObject)Instantiate(StonePrefab, InsPosition.position, Quaternion.identity);
        _Stone.GetComponent<Stone>().m_GameMain = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetStoneNum()
    {
        return _StoneNum;
    }
}
