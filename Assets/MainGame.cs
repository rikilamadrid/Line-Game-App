using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

	public GameObject linePrefab; 

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update()
	{
		CheckMouseInput();

		CheckTouchInput();
	}

	void CheckMouseInput()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Debug.Log ("touching...");

			Instantiate (linePrefab, new Vector3(0, 0, 0), linePrefab.transform.rotation);
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
