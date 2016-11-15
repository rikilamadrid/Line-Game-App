using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

	public GameObject linePrefab; 


	private GameObject line;

	// Use this for initialization
	void Start () {

		line = Instantiate (linePrefab, new Vector3 (8, 0, 0), linePrefab.transform.rotation) as GameObject;
	
	}
	
	// Update is called once per frame
	void Update()
	{
		CheckMouseInput();

		CheckTouchInput();

		if (line != null) 
		{
			//Debug.Log (Time.deltaTime);

			line.transform.Translate(Vector3.left * 1 * Time.deltaTime);

		}
	}

	void CheckMouseInput()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
//			Debug.Log (line.GetComponent<Transform>().position.x);

			Destroy (line);
			line = Instantiate (linePrefab, new Vector3 (8, 0, 0), linePrefab.transform.rotation) as GameObject;

		}
	}

	void CheckTouchInput()
	{
		if (Input.touchCount > 0) 
		{
			if(Input.touches[0].phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
				RaycastHit hitTest;

				if(Physics.Raycast(ray,out hitTest))
				{
					if(hitTest.collider == gameObject.GetComponent<Collider>())
					{
//						SpawnBall(hitTest.point);
					}
				}
			}
		}
	}
}
