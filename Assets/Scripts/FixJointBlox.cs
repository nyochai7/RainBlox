using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixJointBlox : MonoBehaviour
{
	[SerializeField] private List<FixedJoint2D> fixJoints;
	public List<Collider2D> Colliders = new List<Collider2D>();
	[HideInInspector] public Rigidbody2D RigidBody;
	private Collider2D myCollider;

	private void Awake()
	{
		RigidBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.otherRigidbody.CompareTag("ground"))
		{
			return;
		}

		Collider2D tempCollider = collision.collider;

		if (MoveObject.CurrentMovingBlox == this && tempCollider.gameObject.CompareTag("blox"))
		{
			//Debug.Log("going over blocks");

			//foreach (var thing in collisions)
			//{
			//	Debug.Log(thing.gameObject.tag);
			//}

			BloxInteractions.DisableRigidbodys();
			MoveObject.CurrentMovingBlox.Colliders.Add(tempCollider);
			Arrow.IsEnabled = true;
			Arrow.FollowTarget = this.gameObject;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.otherRigidbody.CompareTag("ground"))
		{
			return;
		}

		if (MoveObject.CurrentMovingBlox == this)
		{
			Collider2D tempCollider = collision.collider;
			for (int i = 0; i < MoveObject.CurrentMovingBlox.Colliders.Count; i++)
			{
				if (MoveObject.CurrentMovingBlox.Colliders[i] == tempCollider)
				{
					MoveObject.CurrentMovingBlox.Colliders.Remove(tempCollider);
					break;
				}
			}

			if (Colliders.Count == 0)
			{
				Arrow.IsEnabled = false;
			}

			//PrintCollisionListTags();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			UnJointBlox();
		}
	}

	private void UnJointBlox()
	{
		Vector2	mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (myCollider.bounds.Contains(mouseWorldPosition))
		{
			Debug.Log("check");
		}
	}

	public void StickFixJointBlox()
	{
		if (MoveObject.CurrentMovingBlox == this)
		{
			FixJointBlox fixJointBlox = null;
			////Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			float radius = 1.28f;
			//Debug.Log(collisionList.Count);

			for (int i = 0; i < Colliders.Count; i++)
			{
				//	Debug.Log(collisionList[i].gameObject.tag);

				//	if (false)
				//	{
				float distance = Vector3.Distance(Colliders[i].gameObject.transform.position, MoveObject.currentMovingBlox.transform.position);
				if (distance != 0)
				{
					//Debug.Log(Colliders[i].gameObject.name + " " + distance + " " + MoveObject.currentMovingBlox.name + "  " + (radius * 1.1f));

					if (distance < (radius * 1.1f))
					{
						fixJointBlox = Colliders[i].gameObject.GetComponent<FixJointBlox>();
						if (fixJointBlox != this && fixJointBlox != null)
						{
							break;
						}
					}
				}

			}

			if (fixJointBlox != null && fixJointBlox != this)
			{
				//Debug.Log("joint");
				this.StickBloxes(fixJointBlox);
			}
		}
	}

	private void StickBloxes(FixJointBlox fixJointBlox)
	{
		FixedJoint2D[] fixedJoint2Ds = GetComponents<FixedJoint2D>();
		for (int i = 0; i < fixedJoint2Ds.Length; i++)
		{
			if (fixedJoint2Ds[i].connectedBody == fixJointBlox)
			{
				return;
			}
		}

		if (fixJointBlox.RigidBody != RigidBody)
		{
			FixedJoint2D thisFixedJoint2D = gameObject.AddComponent<FixedJoint2D>();
			FixedJoint2D otherFixedJoint2D = fixJointBlox.gameObject.AddComponent<FixedJoint2D>();

			thisFixedJoint2D.connectedBody = fixJointBlox.RigidBody;
			otherFixedJoint2D.connectedBody = thisFixedJoint2D.attachedRigidbody;

			thisFixedJoint2D.connectedAnchor = fixJointBlox.transform.position;
			otherFixedJoint2D.connectedAnchor = thisFixedJoint2D.transform.position;

			fixJointBlox.fixJoints.Add(otherFixedJoint2D);
			fixJoints.Add(thisFixedJoint2D);
		}
	}
}