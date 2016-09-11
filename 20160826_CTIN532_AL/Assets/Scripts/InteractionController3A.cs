using UnityEngine;
using System.Collections;

public class InteractionController3A : MonoBehaviour 
{

	//Gaze control... 

	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach (GameObject v in GameObject.FindGameObjectsWithTag("Video")) 
		{
			if (Hover (v)) 
			{
				v.GetComponent<VideoSimple> ().hover = true;
			} 
			else 
			{
				v.GetComponent<VideoSimple> ().hover = false;
			}
		}
		
	}

	public bool Hover( GameObject obj )
	{
		Ray ray;
		RaycastHit hit;

		ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		if (Physics.Raycast (ray, out hit)) 
		{
			if (hit.collider == obj.GetComponent<Collider> ()) { return true; }
		}

		return false;
	}
}
