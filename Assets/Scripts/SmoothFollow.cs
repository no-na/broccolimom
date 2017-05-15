using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
	{
	public Transform player;
	
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
		if(xMin < player.position.x)
			xMin = player.position.x;
		
		transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, xMin, xMax),
			Mathf.Clamp(transform.position.y, yMin, yMax),
			-10f
		);
	}
}