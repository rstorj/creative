using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBuilder : MonoBehaviour {
	float timeLeft = 3;
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

		Vector3[] vertices = new Vector3[4];
		Vector3[] normals = new Vector3[4];
		Vector2[] uv = new Vector2[4];

		vertices [0] = new Vector3 (0.0f, 0.0f, 0.0f);
		uv [0] = new Vector2 (0.0f, 0.0f);
		normals [0] = Vector3.up;

		vertices [1] = new Vector3 (0.0f, 0.0f, m_Length);
		uv [1] = new Vector2 (0.0f, 1.0f);
		normals [1] = Vector3.up;

		vertices [2] = new Vector3 (m_Width, 0.0f, m_Length);
		uv [2] = new Vector2 (1.0f, 1.0f);
		normals [2] = Vector3.up;

		vertices [3] = new Vector3 (m_Width, 0.0f, 0.0f);
		uv [3] = new Vector2 (1.0f, 0.0f);
		normals [3] = Vector3.up;

		int[] indices = new int[6]; //2 triangles, 3 indices each

		indices [0] = 0;
		indices [1] = 1;
		indices [2] = 2;

		indices [3] = 0;
		indices [4] = 2;
		indices [5] = 3;

		Mesh mesh = new Mesh ();

		mesh.vertices = vertices;
		mesh.normals = normals;
		mesh.uv = uv;
		mesh.triangles = indices;

		mesh.RecalculateBounds ();

		MeshFilter filter = GetComponent<MeshFilter> ();

		if (filter != null) {
			filter.sharedMesh = mesh;
		}
		timeLeft = 10;
	}
}
