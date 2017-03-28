using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour {


    public GameObject FollowObj;
	public bool StartFollow;
	public bool ResetPosition;
	Vector3 oriPos;
    // Use this for initialization
	void Start () 
	{
		oriPos = transform.position;
		StartFollow = false;
		ResetPosition = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (StartFollow) 
		{
			transform.position = new Vector3 (FollowObj.transform.position.x, transform.position.y,transform.position.z);
		}
		if (transform.position.x >= 10) 
		{
			StartFollow = false;
			FollowObj = null;
		}
		if (ResetPosition) {
			transform.position = Vector3.MoveTowards (transform.position, oriPos, 5 * Time.deltaTime);
		}
		if ((transform.position.x == oriPos.x) && ResetPosition ) {
			ResetPosition = false;
		}
	}
	public void DoFollow(GameObject other)
	{
		FollowObj = other;
		StartFollow = true;
	}
	public void StopFollow()
	{
		FollowObj = null;
		StartFollow = false;
	}
}
