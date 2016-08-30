using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour {

	[SerializeField] Vector3 initPosition;
	[SerializeField] Vector3 interval;
	[SerializeField] int count;
	[SerializeField] GameObject prefab;

	void Awake()
	{
		for ( int i = 0 ; i < count; ++ i )
		{
			Vector3 pos = initPosition + i * interval ;
			GameObject obj = Instantiate( prefab , pos ,Quaternion.identity ) as GameObject;
			obj.transform.parent = transform;
		}
	}

	void OnDrawGizmosSelected()
	{
		for ( int i = 0 ; i < count ; ++ i )
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere( initPosition + interval * i , 0.2f );
		}
	}
}
