using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerAnimController : MonoBehaviour {
	public Animator anim;
	private Rigidbody rigi;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigi = GetComponent<Rigidbody> ();
		anim.Play ("Grow");
	}

	// Update is called once per frame
	void Update () {
	}
}
