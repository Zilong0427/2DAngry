using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	public GameObject deadeffect;
	public GameMain m_GameMain;
	public GameObject AudioControl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D collision) 
	{
		
		if (collision.gameObject.name != "Grass") {
			Instantiate (deadeffect, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
			m_GameMain.IsWin = true;
			AudioControl.GetComponent<AudioControl> ().PlayAudio (2);
		}
	}
}
