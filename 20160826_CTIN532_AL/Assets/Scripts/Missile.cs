using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour 
{

	private float _speed = 2.0f; //can't change params in editor without instants
	public GameObject target; //making this update, find better way ...
	private float _targetDelay = 4.0f;
	private Color _color;

	public void UpdateATL ( ) 
	{
		
		_targetDelay -= Time.deltaTime; //if commented out, disabling transition to seeking the target 

		if (_targetDelay < 0.4f && gameObject.tag == "SpecialMissile") // > aims at target at outset until delay time. < aims at target after delay time
		{
			Quaternion targetDirection = Quaternion.LookRotation (((target.transform.position + target.transform.up * 2.0f) - transform.position).normalized); 
			transform.rotation = Quaternion.Slerp (transform.rotation, targetDirection, Time.deltaTime * 2.0f); 
		}

		//starts out straight
		Vector3 velocity = (transform.forward) * _speed;
		GetComponent< Rigidbody >().MovePosition( transform.position + velocity * Time.deltaTime * 2.0f );

	}

	public void StartATL ( GameObject newTarget, Vector3 startPosition ) 
	{
		target = newTarget; 
		print (target.name);
		_color = new Color ();

		if (gameObject.tag == "SpecialMissile") 
		{
			
			ColorUtility.TryParseHtmlString ("#FFA4FFFF", out _color);
			_color *= 2.0f;

			GetComponent<TrailRenderer> ().material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
			GetComponent<TrailRenderer> ().material.EnableKeyword ("_EMISSION");
			GetComponent< TrailRenderer >().material.SetColor("_TintColor", _color);
		} 
		else if (gameObject.tag == "Missile")
		{
			gameObject.AddComponent< TrailRenderer > (); 
			GetComponent< TrailRenderer > ().material.shader = Shader.Find ("Particles/Additive"); 

			ColorUtility.TryParseHtmlString ("#000000FF", out _color);
			GetComponent< MeshRenderer > ().material.color = _color;

			GetComponent<TrailRenderer> ().material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
			GetComponent<TrailRenderer> ().material.EnableKeyword ("_EMISSION");

			GetComponent< TrailRenderer >().material.SetColor("_TintColor", _color);
		}

		GetComponent< TrailRenderer > ().startWidth = .016f;
		GetComponent< TrailRenderer > ().endWidth = .06f;

		Rigidbody r = gameObject.AddComponent< Rigidbody > ();
		r.isKinematic = true;

		transform.localScale *= .1f; 
		transform.position = startPosition;
	}
}
