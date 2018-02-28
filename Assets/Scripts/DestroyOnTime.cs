using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {


	public float timer = 2.0f;
	// Use this for initialization
	void Start () {

		Invoke ("DestroySelf", timer);
	}
	
	// Update is called once per frame
	void DestroySelf () {

		Destroy (gameObject);
	}
}
