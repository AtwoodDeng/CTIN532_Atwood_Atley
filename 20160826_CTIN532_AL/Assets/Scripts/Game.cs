using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{

	PlayerController player;
	CameraController cam;
	Terrain terrain;

	// Use this for initialization
	void Start () 
	{ 
		player = GameObject.FindObjectOfType< PlayerController > ();
		//player.StartATL ();

		terrain = GameObject.FindObjectOfType< Terrain > ();

		cam = GameObject.FindObjectOfType< CameraController > ();
		//cam.StartATL ();


	}
	
	// Update is called once per frame
	void Update () 
	{
		//player.UpdateATL ();
		//cam.UpdateATL (player); 
	}
}
