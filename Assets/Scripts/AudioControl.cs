using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {
	public AudioSource[] audios;


	public void  PlayAudio(int i){
		audios [i].Play ();
	}
}
