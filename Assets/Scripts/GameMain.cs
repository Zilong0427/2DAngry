using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{

	public CameraFollow _CameraFollow;
    public GameObject StonePrefab;
    [Header("產生球時把彈弓的兩點給予球")]
    public Transform LinePoint1;
    public Transform LinePoint2;

    public bool IsWin;
	Vector3 InsPosition;


    private GameObject _Stone;
    //可以使用的石頭數量，超過還沒打到小鳥就輸了
    private int _StoneNum = 3;
    // Use this for initialization
    void Start()
    {
		InsPosition = (LinePoint1.position + LinePoint2.position) / 2;
        //Init();
    }
    void Init()
    {
        _StoneNum = 3;
		IsWin = false;
        InsNewStone();
    }
    public void InsNewStone()
    {
		if (IsWin) 
		{
			
		}

		if (_StoneNum > 0) 
		{
			_StoneNum -= 1;
			_Stone = (GameObject)Instantiate (StonePrefab, InsPosition, Quaternion.identity);
			Stone _StoneScript = _Stone.GetComponent<Stone> ();
			_StoneScript.m_GameMain = this;
			_StoneScript.LinePoint1 = LinePoint1;
			_StoneScript.LinePoint2 = LinePoint2;
			_StoneScript._CameraFollow = _CameraFollow;
		}
    }

    // Update is called once per frame
    void Update()
    {
		
    }

}
