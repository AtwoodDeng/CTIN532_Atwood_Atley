using UnityEngine;
using System.Collections;

public class Empire : MonoBehaviour 
{
	public GameObject empire;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other) //doesn't register the spline
	{
		if (other.gameObject.tag == "SpecialMissile") 
		{
			empire.transform.localScale *= 1.1f;
		} 
		else if (other.gameObject.tag == "Missile" && empire.transform.localScale.x > 0.01f) 
		{
			empire.transform.localScale *= .9f;
		}
	}
}
