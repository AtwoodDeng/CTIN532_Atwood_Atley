using UnityEngine;
using System.Collections;

public class SelectionLightController : MonoBehaviour 
{

	public bool isHovered = false;
	public bool isSelected = false;
	private Color color;

	void Start () 
	{
		Color color = new Color ();

		GetComponent<Renderer> ().material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
		GetComponent<Renderer> ().material.EnableKeyword ("_EMISSION");
	}
		
	void Update () 
	{
		//print ("selection Light update call");
		//print ("isHovered " + isHovered);
		//print ("isSelected " + isSelected);

		if (isHovered) 
		{
			ColorUtility.TryParseHtmlString ("#2176FF", out color);
			color *= 1.5f; 
		}

		if (isSelected) 
		{
			ColorUtility.TryParseHtmlString ("#4347CC", out color);
			color *= 2.0f;
		} 

		if (!isHovered && !isSelected) 
		{
			ColorUtility.TryParseHtmlString ("#000000", out color);
		}

		GetComponent<Renderer> ().material.SetColor("_EmissionColor", color);
	}
}
