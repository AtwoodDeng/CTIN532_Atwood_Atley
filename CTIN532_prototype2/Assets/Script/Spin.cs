using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	[SerializeField] float spinSpeed = 20f ;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( new Vector3( 0 , 0 , spinSpeed ) * Time.deltaTime );
	}
}
