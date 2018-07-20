using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : VRTK.VRTK_InteractableObject {
	public GameObject waterDrop;
	public Transform startPosition;
	private AudioSource audioSource;

	public override void StartUsing(VRTK.VRTK_InteractUse usingObject)
	{
		base.StartUsing(usingObject);
		pumpWater ();
	}

//	public override void StopUsing(VRTK.VRTK_InteractUse usingObject)
//	{
//		base.StopUsing(usingObject);
//	}

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
