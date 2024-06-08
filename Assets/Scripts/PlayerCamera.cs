using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	[SerializeField] Transform orientation;
	[SerializeField] Transform player;
	[SerializeField] Transform mesh;
	[SerializeField] float cameraAlignTime;
	Camera camera;
	
	void Awake()
	{
		camera = Camera.main;
	}
	
	void Update()
	{
		camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(player.position.x, camera.transform.position.y, player.position.z), Time.deltaTime * cameraAlignTime);
		
		
		Vector2 pointToLook = Input.mousePosition;
		Vector3 point = camera.ScreenToWorldPoint(pointToLook);
		Vector3 viewDirection = player.position - new Vector3(point.x, player.position.y, point.z);
		orientation.forward = -viewDirection.normalized;
		
		mesh.forward = Vector3.Slerp(mesh.forward, orientation.forward, Time.deltaTime * 90);
	}
}
