using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour
{
	public static FixJointBlox currentMovingBlox = null;
	public static FixJointBlox CurrentMovingBlox
	{
		get { return currentMovingBlox; }
		set
		{
			if (value == null && currentMovingBlox != null)
			{
				Arrow.IsEnabled = false;
			}

			currentMovingBlox = value;
		}
	}

	private new Rigidbody2D rigidbody;
	private float speed = 50;
	private bool isFollowingMouse = false;
	private FixJointBlox fixJointBlox;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		fixJointBlox = GetComponent<FixJointBlox>();
	}

	private void Start()
	{
		Arrow.IsEnabled = false;
	}

	private void OnMouseDown()
	{
		if (CurrentMovingBlox != fixJointBlox  && CurrentMovingBlox != null && CurrentMovingBlox.Colliders != null)
		{
			CurrentMovingBlox.Colliders.Clear();
		}

		CurrentMovingBlox = fixJointBlox;
		isFollowingMouse = true;
	}

	private void OnMouseUp()
	{
		if (CurrentMovingBlox == fixJointBlox && CurrentMovingBlox != null)
		{
			BloxInteractions.EnableAllRigidbodys();
			CurrentMovingBlox.StickFixJointBlox();
			isFollowingMouse = false;
			CurrentMovingBlox = null;
		}
	}

	private void OnMouseOver()
	{
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			fixJointBlox.UnJointBlox();
		}
	}

	private void FixedUpdate()
	{
		if (isFollowingMouse)
		{
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			rigidbody.MovePosition(new Vector2(mouseWorldPosition.x * speed * Time.deltaTime, mouseWorldPosition.y * speed * Time.deltaTime));
		}
	}

	private void OnDestroy()
	{
		fixJointBlox.UnJointBlox();
	}
}