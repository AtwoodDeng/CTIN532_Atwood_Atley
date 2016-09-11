using UnityEngine;
using System.Collections;

public class VideoSimple : MonoBehaviour 
{
	
	public MovieTexture movie;
	public bool hover = false;
	
	void Start()
	{
		 
	}

	void Update()
	{
		if ( hover && !movie.isPlaying ) 
		{
			//print ("in hover");

			if (GetComponent<AudioSource> () != null) 
			{
				//fix video codec for audio rolloff - solution is in "code" bookmark
				GetComponent<AudioSource>().clip = movie.audioClip; 
				GetComponent<AudioSource>().Play (); 
			}
			movie.Play (); 
			movie.loop = true;
		}

	}
}
