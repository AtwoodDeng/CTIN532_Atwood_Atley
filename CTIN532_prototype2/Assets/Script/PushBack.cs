using UnityEngine;
using System.Collections;

public class PushBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Character")
		{
			CircleCharacter character = other.gameObject.GetComponent<CircleCharacter>();
			if ( character != null && !character.IsJumping() )
			{
				character.Bounce( (other.gameObject.transform.position - transform.position).normalized );
			}
		}

	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Character")
		{
			CircleCharacter character = other.gameObject.GetComponent<CircleCharacter>();
			if ( character != null && !character.IsJumping()  )
			{
				character.Push( (other.gameObject.transform.position - transform.position).normalized * 5f  );
			}
		}

	}

}
