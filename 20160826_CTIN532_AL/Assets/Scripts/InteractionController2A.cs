using UnityEngine;
using System.Collections;

public class InteractionController2A : MonoBehaviour 
{
	Vector3 oldPosition;
	float oldChangePosition01 = 0.0f;
	public AudioSource _audioSource;
	public GameObject particleSource;
	public GameObject empire;

	private Color _color;

	// Use this for initialization
	void Start () 
	{
		oldPosition = transform.position;
		_audioSource.volume = 1.0f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		//setting bloom intensity relative to amount of movement 
		Vector3 newPosition = transform.position;
		float changePosition = Vector3.Distance (oldPosition, newPosition);
		oldPosition = newPosition;
		float changePosition01 = (changePosition - .05f) * 4.0f;
		float changePosition01smooth = (oldChangePosition01 * 4 + changePosition01) / 5;
		oldChangePosition01 = changePosition01;

		float bloomIntensity = Mathf.Clamp (20.0f / changePosition01smooth, 0.0f, 20.0f);
		Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = bloomIntensity;

		//_audioSource.volume = 1.0f / changePosition01smooth;
		/*
		if (GetComponent<BeatDetectionEvent> ().hithat) 
		{
			particleSource.GetComponent<ParticleSystem> ().startColor = Color.magenta;

		} 
		else if (GetComponent<BeatDetectionEvent> ().snare) 
		{
			particleSource.GetComponent<ParticleSystem> ().startColor = Color.cyan;
		} 
		else if (GetComponent<BeatDetectionEvent> ().kick) 
		{
			particleSource.GetComponent<ParticleSystem> ().startColor = Color.black;
		} 
		else if (GetComponent<BeatDetectionEvent> ().energy) 
		{
			particleSource.GetComponent<ParticleSystem> ().startColor = Color.black;
		}
		*/
		if (GetComponent<BeatDetectionEvent> ().kick) 
		{
			ColorUtility.TryParseHtmlString ("#FFA4FFFF", out _color);
			particleSource.GetComponent<ParticleSystem> ().startColor = _color;
		} 
		else 
		{
			particleSource.GetComponent<ParticleSystem> ().startColor = Color.black;
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			GetComponent<GunController>().Use ( empire ); //params: newTarget game object
		}

	}
}
