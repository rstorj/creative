using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FernBuilder : MonoBehaviour {
	//Still unsure about the scale factor 
	public float scale_factor;

	public int numberofiterations;
	public GameObject dotobject;
	int[] randomsamples;
	float lastx,lasty = 0;
	// Use this for initialization
	void Start () {
		randomsamples = new int[100];
		FillRandomSamples();
		StartCoroutine("CreateFern");
	}

	// Update is called once per frame
	void Update () {

	}

	void FillRandomSamples()
	{
		randomsamples[0] = 1;
		for (int i = 1; i < 85; i++) {
			randomsamples[i] = 2;
		}
		for (int i = 85; i < 92; i++) {
			randomsamples[i] = 3;
		}
		for (int i = 92; i < 100; i++) {
			randomsamples[i] = 4;
		}
	}

	IEnumerator CreateFern()
	{
		for(int i = 0; i < numberofiterations; i++)
		{
			int randomvalue = randomsamples[Random.Range(0, randomsamples.Length)];
			Vector2 newpos;
			switch (randomvalue) {
			case 1:
				newpos = function1(new Vector2(lastx, lasty));
				lastx = newpos.x;
				lasty = newpos.y;
				Instantiate(dotobject, newpos, Quaternion.identity);
				break;
			case 2:
				newpos = function2(new Vector2(lastx, lasty));
				lastx = newpos.x;
				lasty = newpos.y;
				Instantiate(dotobject, newpos, Quaternion.identity);
				break;
			case 3:
				newpos = function3(new Vector2(lastx, lasty));
				lastx = newpos.x;
				lasty = newpos.y;
				Instantiate(dotobject, newpos, Quaternion.identity);
				break;
			case 4:
				newpos = function4(new Vector2(lastx, lasty));
				lastx = newpos.x;
				lasty = newpos.y;
				Instantiate(dotobject, newpos, Quaternion.identity);
				break;
			default:
				break;
			}
			yield return new WaitForSeconds(0);
		}
		Debug.Log("Finished");
	}


	Vector2 function1(Vector2 inputs)
	{
		Vector2 outputs = new Vector2();
		outputs.x = 0;
		outputs.y = 0.16f * inputs.y * scale_factor;
		return outputs;
	}

	Vector2 function2(Vector2 inputs)
	{
		Vector2 outputs = new Vector2();
		outputs.x = (inputs.x * 0.85f + 0.04f * inputs.y) * scale_factor;
		outputs.y = (inputs.x * -0.04f + 0.85f * inputs.y + 1.6f) * scale_factor;
		return outputs;
	}

	Vector2 function3(Vector2 inputs)
	{
		Vector2 outputs = new Vector2();
		outputs.x = (0.2f * inputs.x - 0.26f * inputs.y) * scale_factor;
		outputs.y = (0.23f * inputs.x + 0.22f * inputs.y + 1.6f) * scale_factor;
		return outputs;
	}
	Vector2 function4(Vector2 inputs) {
		Vector2 outputs = new Vector2();
		outputs.x = (-0.15f * inputs.x + 0.28f * inputs.y) * scale_factor;
		outputs.y = (0.26f * inputs.x + 0.24f * inputs.y + 0.44f) * scale_factor;  
		return outputs;
	}
}