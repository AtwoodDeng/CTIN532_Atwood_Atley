using UnityEngine;
using System.Collections;

public class SystemControl : MonoBehaviour {

	[SerializeField] GameObject[] Lvls;
	[SerializeField] GameObject[] characters;
	[SerializeField] float interval;

	int index = 0;
	// Use this for initialization
	void Start () {
		Lvls[index].SetActive( true );
	}

	float timer = 0;
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if ( timer > interval )
		{
			if ( Input.GetKeyDown(KeyCode.Space) )
			{
				Vector3 characterPos = characters[index].transform.position;
				Lvls[index].SetActive(false);
				index = ( index + 1 ) % Lvls.Length;
			
				Lvls[index].SetActive( true );
				characters[index].transform.position = characterPos;
				timer = 0;

				interval *= 0.8f;
			}
		}
	}


}
