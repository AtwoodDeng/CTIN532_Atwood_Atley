using UnityEngine;
using System.Collections;

public class MainTriangle : MonoBehaviour {

	[SerializeField] float acc = 0.1f;
	[SerializeField] float maxSpeed = 0.5f;
	[SerializeField] float width = 2f;
	[SerializeField] float jumpSpeed = 1f;

	Rigidbody2D rigid2D;

	// Use this for initialization
	void Start () {
		rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 accV3 = acc * new Vector3( Input.GetAxis("Horizontal") , 0 ) * (isInAir? 0.5f : 1f );

		rigid2D.AddForce( accV3 );

		rigid2D.velocity = Vector3.ClampMagnitude( rigid2D.velocity , maxSpeed * (isInAir? 2.2f : 1f ) );

		if ( transform.position.x > Global.GetFrame().x + width /2f )
			transform.position -= new Vector3( Global.GetFrame().x * 2f + width , 0 , 0 );

		if ( transform.position.x < - Global.GetFrame().x - width /2f )
			transform.position += new Vector3( Global.GetFrame().x * 2f + width , 0 , 0 );


		if ( transform.position.y > Global.GetFrame().y + width /2f )
			transform.position -= new Vector3( 0 , Global.GetFrame().y * 2f + width , 0 );

		if ( transform.position.y < - Global.GetFrame().y - width /2f )
			transform.position += new Vector3( 0 , Global.GetFrame().y * 2f + width , 0 );

		if ( Input.GetKeyDown(KeyCode.Space ) )
		{
			Jump();
		}
	}

	bool isInAir = true;

	void Jump()
	{
		if ( isInAir == false )
		{
			isInAir = true;
			rigid2D.AddForce( Vector3.up * jumpSpeed * 100f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if ( coll.gameObject.tag == "Platform" )
		{
			isInAir = false;
		}
	}

	void OnCollisionExit2D( Collision2D coll ) {
		if ( coll.gameObject.tag == "Platform" )
		{
			isInAir = true;
		}
	}
}
