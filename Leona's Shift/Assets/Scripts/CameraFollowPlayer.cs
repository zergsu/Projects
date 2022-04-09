using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float smoothing;
    Vector3 offset = new Vector3(0 ,0 ,-1);

	private void Start()
	{
        smoothing = 0.006f;

    }
	void Update()
    {
        if (player != null)
		{
            Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            newPosition += new Vector3(0, 0.005f, 0);
            transform.position = new Vector3(newPosition.x, newPosition.y, -1);
		}
    }
}
