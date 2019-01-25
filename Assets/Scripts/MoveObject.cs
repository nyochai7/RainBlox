using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour//, IPointerDownHandler
{
	private Rigidbody2D rigidbody;
	//private Vector2 lastMousePosition;
	private float speed = 50;
	private bool isFollowingMouse = false;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	//public void OnPointerDown(PointerEventData eventData)
	//{
	//	rigidbody.MovePosition(eventData.delta);
	//}

	private void OnMouseDown()
	{
		isFollowingMouse = true;
	}

	private void OnMouseUp()
	{
		isFollowingMouse = false;
	}

	private void FixedUpdate()
	{
		if (isFollowingMouse)
		{
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			rigidbody.MovePosition(new Vector2(mouseWorldPosition.x * speed * Time.deltaTime, mouseWorldPosition.y * speed * Time.deltaTime));
		}
	}

	//private void OnMouseUp()
	//{
	//	//Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	//	//rigidbody.MovePosition(new Vector2(mouseWorldPosition.x * speed * Time.deltaTime, mouseWorldPosition.y * speed * Time.deltaTime));
	//	//lastMousePosition = Input.mousePosition;
	//}

	//float speed = 10f;
	//Vector3 target;
	//Vector3 start;
	//private Vector3 pos;
	//private BoxCollider2D collider;

	//void Start()
	//{
	//	start = transform.position;
	//	pos = transform.position;
	//	collider = GetComponent<BoxCollider2D>();
	//}

	//void Update()
	//{
	//	if (Input.GetMouseButton(0))
	//	{
	//		pos = Input.mousePosition;
	//		pos.z = 45;
	//		pos = Camera.main.ScreenToWorldPoint(pos);
	//	}

	//	transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
	//}
}