using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour {


    public GameObject FollowObj;
	public bool StartFollow;

    // Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (StartFollow) {
			transform.position = new Vector3 (FollowObj.transform.position.x, transform.position.y,transform.position.z);
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
