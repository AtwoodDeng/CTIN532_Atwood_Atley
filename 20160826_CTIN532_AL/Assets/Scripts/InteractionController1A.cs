using UnityEngine;
using System.Collections;

public class InteractionController1A : MonoBehaviour 
{
	GameObject female;
	GameObject reproductiveSystem;
	float oldDistance;

	// Use this for initialization
	void Start () 
	{
		female = GameObject.Find ("female");
		reproductiveSystem = GameObject.Find ("Female_Reproductive_System");
		oldDistance = Vector3.Distance (transform.position, female.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float newDistance = Vector3.Distance (transform.position, female.transform.position);
		float changeInDistance = newDistance - oldDistance;
		oldDistance = newDistance;

		//AxKDebugLines.AddFancySphere (female.transform.position + female.transform.forward + female.transform.up, changeInDistance, Color.red, 0);

		if (reproductiveSystem.transform.localScale.x < 1.0f) 
		{
			reproductiveSystem.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			//print ("freeze scale = " + reproductiveSystem.transform.localScale);

		}

		if (reproductiveSystem.transform.localScale.x > 21.36f) 
		{
			reproductiveSystem.transform.localScale = new Vector3(21.36f, 21.36f, 21.36f);
		}



		if (reproductiveSystem.transform.localScale.x >= .9f && reproductiveSystem.transform.localScale.x <= 21.4f) 
		{
			reproductiveSystem.transform.localScale *= (1.0f - changeInDistance);
			//print ("transform scale = " + reproductiveSystem.transform.localScale);
		}



		//reproductiveSystem.transform.localPosition.z -= 1 / distance;
		//female.transform.localRotation.y -= distance;
		//reproductiveSystem.transform.y += distance;


	
	}
}
