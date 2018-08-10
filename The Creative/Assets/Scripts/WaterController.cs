using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {
	public GameObject waterDrop;
	public Transform startPosition;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("1")){
			if (!IsInvoking("pumpWater")){
				Invoke("pumpWater", 0f);
			}
		}
	

	}		

	void pumpWater(){
		GameObject droplet = Instantiate (waterDrop) as GameObject;
		waterDrop.transform.position = startPosition.position;
		audioSource.PlayOneShot(SoundManager.Instance.waterDropClip);
	}


}
