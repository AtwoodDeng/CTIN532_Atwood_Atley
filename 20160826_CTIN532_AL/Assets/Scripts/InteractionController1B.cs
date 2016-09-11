using UnityEngine;
using System.Collections;

public class InteractionController1B : MonoBehaviour 
{
	Vector3 oldPosition;
	float oldChangePosition01 = 0.0f;
	public AudioSource _audioSource;

	// Use this for initialization
	void Start () 
	{
		oldPosition = transform.position;
		_audioSource = GetComponent<AudioSource> ();
		_audioSource.volume = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPosition = transform.position;

		float changePosition = Vector3.Distance (oldPosition, newPosition);
		print ("change position = " + changePosition); //range .07 to .3

		oldPosition = newPosition;

		float changePosition01 = (changePosition - .05f) * 4.0f;
		print ("1 / change position 01 = " + changePosition01);

		float changePosition01smooth = (oldChangePosition01 * 4 + changePosition01) / 5;

		oldChangePosition01 = changePosition01;

		float bloomIntensity = Mathf.Clamp (20.0f / changePosition01smooth, 0.0f, 20.0f);

		Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = bloomIntensity;

		_audioSource.volume = 1.0f / changePosition01smooth;

	}
}
