using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour 
{

	private List < Missile > _missiles = new List < Missile > ();
	public Transform muzzle;
	public AudioSource _audiosource1;
	public AudioSource _audiosource2;

	public GameObject prefab;

	// Use this for initialization
	public void Start () 
	{
		
	}
	
	// Update is called once per frame
	public void Update () 
	{

		for (int i = 0; i < _missiles.Count; i++) 
		{
			_missiles [i].UpdateATL ( ); //could pass player, but just using camera 
		}
			
	}

	public void Use ( GameObject newTarget )
	{
		
		GameObject newGameObject;
		Missile _missile;

		if (GetComponent<BeatDetectionEvent> ().kick || GetComponent<BeatDetectionEvent> ().snare) // || GetComponent<BeatDetectionEvent> ().hithat || GetComponent<BeatDetectionEvent> ().energy) 
		{ 
			newGameObject = GameObject.Instantiate (prefab);
			_missile = newGameObject.GetComponent< Missile > ();
			_missile.tag = "SpecialMissile";
			_audiosource1.Play ();
		} 
		else 
		{
			newGameObject = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			_missile = newGameObject.AddComponent< Missile > ();
			_missile.tag = "Missile";
			_audiosource2.Play ();
		}
		newGameObject.transform.forward = Camera.main.transform.forward;

		_missile.StartATL( newTarget, muzzle.position ) ; // endTarget, startPosition
		RegisterMissile (_missile);
	}

	void RegisterMissile ( Missile missileToAdd )
	{
		_missiles.Add (missileToAdd);
	}
}
