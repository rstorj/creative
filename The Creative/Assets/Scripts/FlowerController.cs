using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {
	public GameObject flower1;
	public GameObject flower2;
	public GameObject flower3;
	public GameObject flower4;
	public GameObject flower5;
	public GameObject flower6;

	private GameObject flower;

	public Vector3 growSpot;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "WaterDrop(Clone)") {
			Debug.Log ("wow a flower");
			Debug.Log (other.transform.position);
			growSpot = other.transform.position;

			int flowerNumber = (int)(Random.value*10);

			switch (flowerNumber){
			case 1:
				flower = flower1;
				break;
			case 2:
				flower = flower2;
				break;
			case 3:
				flower = flower3;
				break;
			case 4:
				flower = flower4;
				break;
			case 5:
				flower = flower5;
				break;
			case 6:
				flower = flower1;
				break;
			case 7:
				flower = flower2;
				break;
			case 8:
				flower = flower3;
				break;
			case 9: 
				flower = flower4;
				break;
			case 10:
				flower = flower5;
				break;
			default:
				flower = flower6;
				break;
			}

			GameObject sprout = Instantiate (flower) as GameObject;
			Destroy (other.gameObject);

			sprout.transform.position = growSpot;
		}
	
	}
		
}




