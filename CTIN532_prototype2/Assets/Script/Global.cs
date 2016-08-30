using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	[SerializeField] float interval;
	[SerializeField] AnimationCurve curve;
	public static Global Instance;
	Global() { if ( Instance == null ) Instance = this; }
	static float[] samples;
	static int frequency;
	static int score = 0;

	void Awake()
	{
		AudioSource aud = GetComponent<AudioSource>();
		samples = new float[aud.clip.samples * aud.clip.channels];
		aud.clip.GetData(samples, 0);
		frequency = aud.clip.frequency;

	}

	public static float GetVolume() { return samples[(int)(Time.time * frequency)]; }

	public static float GetProcess() { return Instance.curve.Evaluate( Time.time / Instance.interval ) ;  }

	public static Vector2 GetFrame () { return new Vector2( 9f , 5f ); }

	public static void AddScore() { score ++; }
	public static int GetScore () { return score; }

}
