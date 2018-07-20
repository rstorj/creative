using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FernMeshBuilder : MonoBehaviour {
	float timeLeft = 5;
	// Use this for initialization
	void Start () {
		makeMesh ();

	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			makeMesh ();

		}
	}

	void makeMesh (){
		float m_Length = Random.value;
		float m_Width = Random.value;

		Vector3[] vertices = new Vector3[8];
	//	Vector3[] normals = new Vector3[8];
	//	Vector2[] uv = new Vector2[8];

		for (int i =0; i < vertices.Length; i++){
		
			vertices [i] = new Vector3 (Random.value, Random.value, Random.value);
	//		uv [0] = new Vector2 (Random.value, Random.value);
	//		normals [0] = Vector3.up;
		}
		int[] indices = new int[6]; //2 triangles, 3 indices each

		indices [0] = 0;
		indices [1] = 1;
		indices [2] = 2;

		indices [3] = 0;
		indices [4] = 2;
		indices [5] = 3;

	

		Mesh mesh = new Mesh ();

		mesh.vertices = vertices;
	//	mesh.normals = normals;
	//	mesh.uv = uv;
		mesh.triangles = indices;

		mesh.RecalculateBounds ();

		MeshFilter filter = GetComponent<MeshFilter> ();

		if (filter != null) {
			filter.sharedMesh = mesh;
		}
		timeLeft = 5;
	}
}
