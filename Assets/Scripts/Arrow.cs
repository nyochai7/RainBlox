using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	[SerializeField] private GameObject actualArrow;
	public Transform Tip;
	public static GameObject FollowTarget;
	public static bool IsEnabled { private get; set; }
	
	private void Update()
	{
		if (IsEnabled && FollowTarget != null)
		{
			actualArrow.gameObject.SetActive(true);
			transform.position = FollowTarget.transform.position;
			Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float angle = -Mathf.Atan2(mouseWorldPosition.y - transform.position.y, mouseWorldPosition.x - transform.position.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, 0, -angle);
		}
		else
		{
			actualArrow.gameObject.SetActive(false);
		}
	}
}