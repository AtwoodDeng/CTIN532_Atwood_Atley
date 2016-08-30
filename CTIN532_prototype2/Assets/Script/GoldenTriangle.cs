using UnityEngine;
using System.Collections;

public class GoldenTriangle : MonoBehaviour {

	[SerializeField] Vector3 acc;
	[SerializeField] Vector3 basicSpeed;
	[SerializeField] float drag = 0.95f;
	[SerializeField] float width = 2f;
	[SerializeField] Golden golden;
	Vector3 speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		speed += acc * Time.deltaTime * Mathf.Pow( Global.GetVolume() * 10f , 2f ) ;
		speed *= drag;
		speed = basicSpeed.normalized * Mathf.Clamp( speed.magnitude , basicSpeed.magnitude , basicSpeed.magnitude * 5f );

		transform.position += speed * Time.deltaTime ;



		if ( transform.position.x > Global.GetFrame().x + width /2f )
		{
			transform.position -= new Vector3( Global.GetFrame().x * 2f + width , 0 , 0 );
			golden.Reset();
		}

		if ( transform.position.x < - Global.GetFrame().x - width /2f )
		{
			transform.position += new Vector3( Global.GetFrame().x * 2f + width , 0 , 0 );
			golden.Reset();
		}


		if ( transform.position.y > Global.GetFrame().y + width /2f )
		{
			transform.position -= new Vector3( 0 , Global.GetFrame().y * 2f + width , 0 );
			golden.Reset();
		}

		if ( transform.position.y < - Global.GetFrame().y - width /2f )
		{
			transform.position += new Vector3( 0 , Global.GetFrame().y * 2f + width  , 0 );
			golden.Reset();
		}
	}
}
