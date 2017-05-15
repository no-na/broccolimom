using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
	{
	
	[SerializeField]
	private float xMin = 0f;
	[SerializeField]
	private float xMax = 0f;
	[SerializeField]
	private float yMin = 0f;
	[SerializeField]
	private float yMax = 0f;
	
	
	// The transforms of the players. Used to determine their midpoint.
	[SerializeField]
	private Transform sisterTransform;
	[SerializeField]
	private Transform brotherTransform;

	void Update()
	{
		if(xMin < transform.position.x)
			xMin = transform.position.x;
		
		transform.position = GetMidpoint();
	}
	
	//returns the transform of the midpoint of the brother and sister.
	//This point is what the camera focuses on.
	Vector3 GetMidpoint()
	{
		return new Vector3(
			GetAverage(sisterTransform.position.x , brotherTransform.position.x),
			GetAverage(sisterTransform.position.y , brotherTransform.position.y),
			-10f
		);
	}
	
	
	//returns a X,Y, or Z position to be used as a midpoint
	float GetAverage(float a, float b)
	{
		return (a+b)/2f;
	}
}