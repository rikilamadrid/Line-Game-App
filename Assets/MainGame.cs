using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainGame : MonoBehaviour {

	public GameObject linePrefab; 
	public Text lifesObject;
	public int lifes = 3;


	private GameObject line;
	private int speed = 1;


	// Use this for initialization
	void Start () {

		line = Instantiate (linePrefab, new Vector3 (4, 0, 0), linePrefab.transform.rotation) as GameObject;
		lifes = 3;
		Debug.Log (lifesObject.text);


	
	}
	
	// Update is called once per frame
	void Update()
	{
		lifesObject.text = "Lifes: " + lifes.ToString();

		CheckMouseInput();

		CheckTouchInput();

		if (line != null) 
		{
			//Debug.Log (Time.deltaTime);

			line.transform.Translate(Vector3.left * speed * Time.deltaTime);


		}
	}

	void CheckMouseInput()
	{
		if (Input.GetMouseButtonDown (0))
		{
			if (line != null) 
			{
				if (line.GetComponent<Transform>().position.x > -1 && line.GetComponent<Transform>().position.x < 1) 
				{
					Debug.Log ("In the zone: " + line.GetComponent<Transform>().position.x.ToString());
					Destroy (line);
					line = Instantiate (linePrefab, new Vector3 (4, 0, 0), linePrefab.transform.rotation) as GameObject;
					speed++;
					Debug.Log ("SPEED: " + speed + " and LIFES is: " + lifes);
				} else 
				{
					Debug.Log ("NOT in the zone: " + line.GetComponent<Transform>().position.x.ToString());
					Destroy (line);
					line = Instantiate (linePrefab, new Vector3 (4, 0, 0), linePrefab.transform.rotation) as GameObject;
					//speed--;
					lifes--;
//					lifesObject.text = "Lifes: " + lifes.ToString();
					Debug.Log ("SPEED: " + speed + " and LIFES is: " + lifes);
					Debug.Log ("lifesObject text is: " + lifesObject.text);

				}
			}
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
