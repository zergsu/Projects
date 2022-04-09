using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 point1, point2;
	float dir;
	public float speed = 1;
	
	private void Start()
	{
		dir = -0.065f;
	}

	void Update()
    {
		if (transform.position.x >= point2.x)
		{
			dir *= -1;
		}
		else if (transform.position.x <= point1.x) 
		{
			dir *= -1;
		}
	}

	private void FixedUpdate()
	{
		transform.position = Vector3.MoveTowards(transform.position, point2, speed * Time.fixedDeltaTime);
	}
}
