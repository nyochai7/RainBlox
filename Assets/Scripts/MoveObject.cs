using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour
{
	public static GameObject CurrentMovingBlox = null;
	private Rigidbody2D rigidbody;
	private float speed = 50;
	private bool isFollowingMouse = false;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void OnMouseDown()
	{
		CurrentMovingBlox = gameObject;
		isFollowingMouse = true;
	}

	private void OnMouseUp()
	{
		isFollowingMouse = false;
		StartCoroutine(WaitFrame());
	}

	IEnumerator WaitFrame()
	{
		yield return null;
		CurrentMovingBlox = null;
	}

	private void FixedUpdate()
	{
		if (isFollowingMouse)
		{
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			rigidbody.MovePosition(new Vector2(mouseWorldPosition.x * speed * Time.deltaTime, mouseWorldPosition.y * speed * Time.deltaTime));
		}
	}
}