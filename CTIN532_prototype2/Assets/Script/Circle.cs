using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

	[SerializeField] Vector3 acc;
	[SerializeField] Vector3 basicSpeed;
	[SerializeField] float drag = 0.95f;
	[SerializeField] float width = 2f;
	[SerializeField] float smallCircleRadius = 2f;
	[SerializeField] Golden smallCircle;
	Vector3 speed;

	float offset = 1f;

	void Start()
	{
		offset = Random.Range( 0 , Mathf.PI * 2f );
	}

	void Update()
	{
		speed += acc * Time.deltaTime * Mathf.Pow( Global.GetVolume() * 10f , 2f );
		speed *= drag;
		speed = basicSpeed.normalized * Mathf.Clamp( speed.magnitude , basicSpeed.magnitude , basicSpeed.magnitude * 5f );

		transform.position += speed * Time.deltaTime ;



		if ( transform.position.x > Global.GetFrame().x + width /2f )
		{
			transform.position -= new Vector3( Global.GetFrame().x * 2f + width , 0 , 0 );
			smallCircle.Reset();
		}

		if ( transform.position.x < - Global.GetFrame().x - width /2f )
		{
			transform.position += new Vector3( Global.GetFrame().x * 2f + width , 0 , 0 );
			smallCircle.Reset();
		}


		if ( transform.position.y > Global.GetFrame().y + width /2f )
		{
			transform.position -= new Vector3( 0 , Global.GetFrame().y * 2f + width , 0 );
			smallCircle.Reset();
		}

		if ( transform.position.y < - Global.GetFrame().y - width /2f )
		{
			transform.position += new Vector3( 0 , Global.GetFrame().y * 2f + width  , 0 );
			smallCircle.Reset();
		}
		

		if ( smallCircle != null )
		{
			float alpha = Global.GetProcess() * Mathf.PI * 2f + offset;
			smallCircle.transform.localPosition = new Vector3( smallCircleRadius * Mathf.Cos( alpha ) , smallCircleRadius * Mathf.Sin( alpha ));
		}
			

	}
}
