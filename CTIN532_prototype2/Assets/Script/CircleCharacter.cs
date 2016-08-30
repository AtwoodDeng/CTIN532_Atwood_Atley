using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CircleCharacter : MonoBehaviour {
	[SerializeField] float acc = 0.1f;
	[SerializeField] float drag = 0.9f;
	[SerializeField] float maxSpeed = 0.5f;
	[SerializeField] float width = 2f;
	[SerializeField] float lostControlTime = 0.5f;
	[SerializeField] float jumpDuration = 1f;
	[SerializeField] float jumpDistance = 2f;
	Vector3 speed;
	float lostControlTimer = 999f;

	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {

		lostControlTimer += Time.deltaTime;


		Vector3 accV3 = acc * new Vector3( Input.GetAxis("Horizontal") , Input.GetAxis("Vertical") , 0 );
		if ( lostControlTimer < lostControlTime  || isJumpping )
		{
			accV3 = Vector3.zero;
		}
		speed += accV3 * Time.deltaTime;
		speed = Vector3.ClampMagnitude( speed , maxSpeed );

		transform.position += speed * Time.deltaTime * (isJumpping? 3.5f : 1f );

		speed *= isJumpping ? 1f : drag;


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

	bool isJumpping =false;

	public void Jump()
	{
		if ( !isJumpping )
		{
			
			isJumpping = true;
			Sequence seq = DOTween.Sequence();
			seq.Append( transform.DOScale( 1.8f , jumpDuration / 2f ).SetEase(Ease.InCirc) );
			seq.Append( transform.DOScale( 1f , jumpDuration / 2f ).SetEase(Ease.OutCirc) );
			seq.AppendCallback(EndJump);

			GetComponent<Collider2D>().isTrigger = true;
		}
	}

	public void EndJump()
	{
		isJumpping = false;
		GetComponent<Collider2D>().isTrigger = false;
	}

	public void Bounce( Vector3 direction )
	{
		float rate = Vector3.Dot( direction.normalized , speed );
		if ( rate < 0 )
		{
			speed += direction * rate * (-30f);
		}

		lostControlTimer = 0;
	}

	public void Push( Vector3 force )
	{
		speed += force;

	}

	public bool IsJumping() { return isJumpping ; }

}
