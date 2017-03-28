using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMain : MonoBehaviour
{

	public CameraFollow _CameraFollow;
    public GameObject StonePrefab;
    [Header("產生球時把彈弓的兩點給予球")]
    public Transform LinePoint1;
    public Transform LinePoint2;
	public GameObject Scene2;
	public GameObject Bird1, Bird2;
    public bool IsWin;
	public GameObject win, lose;
	public GameObject AudioControl;

	Vector3 InsPosition;

	bool GoScene2 = false;
    private GameObject _Stone;
    //可以使用的石頭數量，超過還沒打到小鳥就輸了
    private int _StoneNum = 3;
    // Use this for initialization
    void Start()
    {
		InsPosition = (LinePoint1.position + LinePoint2.position) / 2;
        Init();
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
			StartCoroutine (ShowUI (win));
			_CameraFollow.ResetPosition = true;
			Bird1.SetActive (false);
			Bird2.SetActive (true);
			GoScene2 = true;
			Init ();
		}

		else if (_StoneNum > 0) 
		{
			_StoneNum -= 1;
			_Stone = (GameObject)Instantiate (StonePrefab, InsPosition, Quaternion.identity);
			Stone _StoneScript = _Stone.GetComponent<Stone> ();
			_StoneScript.m_GameMain = this;
			_StoneScript.AudioControl = AudioControl;
			_StoneScript.LinePoint1 = LinePoint1;
			_StoneScript.LinePoint2 = LinePoint2;
			_StoneScript._CameraFollow = _CameraFollow;
			_StoneScript.Init ();
			_CameraFollow.ResetPosition = true;
		}

		else if (_StoneNum == 0) 
		{
			StartCoroutine (ShowUI (lose));
			Init ();
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (GoScene2) {
			Scene2.transform.position = Vector3.MoveTowards (Scene2.transform.position, new Vector3 (0, -18, 0), 5 * Time.deltaTime);
		}	
    }
	IEnumerator ShowUI(GameObject gameobj){
		gameobj.SetActive (true);
		yield return new WaitForSeconds (3f);
		gameobj.SetActive (false);
	}
}
