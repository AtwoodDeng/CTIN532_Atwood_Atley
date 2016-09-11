using UnityEngine;
using System.Collections;

public class BeatDetectionEvent : MonoBehaviour 
{

	public bool energy = false;
	public bool kick = false;
	public bool snare = false;
	public bool hithat = false;

	public int mult = 5;

	public void MyCallbackEventHandler(BeatDetection.EventInfo eventInfo)
	{
		switch(eventInfo.messageInfo)
		{
		case BeatDetection.EventType.HitHat:
			hithat = true;
			//print ("hithat: " + hithat);
			StartCoroutine(HitHat());
			break;

		case BeatDetection.EventType.Snare:
			snare = true;
			//print ("snare: " + snare);
			StartCoroutine(Snare());
			break;

		case BeatDetection.EventType.Kick:
			kick = true;
			//print ("kick: " + hithat);
			StartCoroutine(Kick());
			break;

		case BeatDetection.EventType.Energy:
			energy = true;
			//print ("energy: " + hithat);
			StartCoroutine(Energy());
			break;
		}
	}

	public void Update()
	{
		//bools only true for one frame
		/*
		if (hithat) 
		{
			hithat = false;
		}
		if (snare) 
		{
			snare = false;
		}
		if (kick) 
		{
			kick = false;
		}
		if (energy) 
		{
			energy = false;
		}
		*/
	}

	private IEnumerator HitHat()
	{
		hithat = true;
		//print ("hithat: " + hithat);
		yield return new WaitForSeconds(0.05f * mult);

		hithat = false;
		yield break;
	}

	private IEnumerator Snare()
	{
		snare = true;
		//print ("snare: " + snare);
		yield return new WaitForSeconds(0.05f * mult);

		snare = false;
		yield break;
	}

	private IEnumerator Kick()
	{
		kick = true;
		//print ("kick: " + kick);
		yield return new WaitForSeconds(0.05f * mult);

		kick = false;
		yield break;
	}

	private IEnumerator Energy()
	{
		energy = true;
		//print ("energy: " + energy);
		yield return new WaitForSeconds(0.05f);

		energy = false;
		yield break;
	}

	void Start () 
	{
		//Register the beat callback function
		GetComponent<BeatDetection>().CallBackFunction = MyCallbackEventHandler;
	}

}

