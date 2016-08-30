using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Golden : MonoBehaviour {

	[SerializeField] AudioSource audio;
	Vector3 initScale;
	// Use this for initialization
	void Start () {
		initScale = transform.localScale;
		if ( audio == null )
			audio = GetComponent<AudioSource>();
		if (audio != null )
			audio.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ( other.tag == "Character" )
		{
			Global.AddScore();

			transform.DOScale( 1.5f , 1f ).SetRelative(true).SetEase(Ease.OutCubic ).OnComplete(SelfDestory);

			SpriteRenderer sprite = GetComponent<SpriteRenderer>();
			if ( sprite != null )
			{
				sprite.DOFade( 0 , 1f ).SetEase(Ease.OutCubic );
			}
			if ( audio != null )
				audio.Play();
		}
	}

	void SelfDestory()
	{
		gameObject.SetActive( false );
	}

	public void Reset()
	{
		transform.localScale = initScale;

		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if ( sprite != null )
		{
			sprite.DOFade( 1f , 0 );
		}

		gameObject.SetActive(true);
	}
}
