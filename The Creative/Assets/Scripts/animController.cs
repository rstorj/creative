using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour {
	public Animator anim;
	private AudioSource audioSource;
	private Collider col;
	private Rigidbody rigi;
	public Vector3 growSpot;
	public GameObject flower;



	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		col = GetComponent<Collider> ();
		rigi = GetComponent<Rigidbody> ();
	
		anim.Play("WaterDropping");
		audioSource.PlayOneShot(SoundManager.Instance.waterDropClip);
	}

	// Update is called once per frame
	void Update () {
	}
	void OnCollisionEnter(Collision collision){
		if (collision.transform.gameObject.name == "TheCreativeTerrain4") {
			anim.Play ("IntoGround");
			Debug.Log (gameObject.transform.position);
			growSpot = gameObject.transform.position;
			GameObject sprout = Instantiate (flower) as GameObject;
			sprout.transform.position = growSpot;
			Destroy (col);
		} else if (collision.transform.gameObject.name == "Basin") {
			rigi.constraints = RigidbodyConstraints.FreezeAll;
			Debug.Log ("Basin");
		} else if (collision.transform.gameObject.name == "Cube") {
			rigi.constraints = RigidbodyConstraints.None;
			Debug.Log ("Cube");
		} else if (collision.transform.gameObject.name == "Player") {
			Debug.Log ("Player");
		}
	}
}
