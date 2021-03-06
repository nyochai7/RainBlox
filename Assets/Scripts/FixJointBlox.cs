﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixJointBlox : MonoBehaviour
{
	[HideInInspector] public List<Collider2D> Colliders = new List<Collider2D>();
	[HideInInspector] public List<FixedJoint2D> FixJoints = new List<FixedJoint2D>();
	[HideInInspector] public Rigidbody2D RigidBody;

	private void Awake()
	{
		RigidBody = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("ground"))
		{
			return;
		}

		Collider2D tempCollider = collision.collider;

		if (MoveObject.CurrentMovingBlox == this && tempCollider.gameObject.CompareTag("blox"))
		{
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
		}
	}
    private void OnCollisionStay(Collision collision)
    {
        if(MoveObject.CurrentMovingBlox == this)
        {
            
        }
    }

    public void UnJointBlox()
	{
		FixedJoint2D[] joints = FindObjectsOfType<FixedJoint2D>();
		for (int i = joints.Length - 1; i >= 0 ; i--)
		{
			if(joints[i].connectedBody == RigidBody)
			{
				Destroy(joints[i]);
			}
		}

		for (int i = FixJoints.Count - 1; i >= 0; i--)
		{
			Destroy(FixJoints[i]);
		}

		FixJoints.Clear();
	}

	public void StickFixJointBlox()
	{
		if (MoveObject.CurrentMovingBlox == this)
		{
			FixJointBlox fixJointBlox = null;

			for (int i = 0; i < Colliders.Count; i++)
			{
                Collider2D[] overlappingColliders = Physics2D.OverlapBoxAll((Vector2)transform.position,
                                                                       (Vector2)GetComponent<Collider2D>().bounds.size,
                                                                        transform.rotation.eulerAngles.z,
                                                                        LayerMask.GetMask("Blox"));

                foreach(Collider2D collider in overlappingColliders)
                {
                    fixJointBlox = collider.GetComponent<FixJointBlox>();
                    if (fixJointBlox != this && fixJointBlox != null)
                    {
                        break;
                    }
                }
			}

			if (fixJointBlox != null && fixJointBlox != this)
			{
				this.StickBloxes(fixJointBlox);
			}
		}
	}

	private void StickBloxes(FixJointBlox fixJointBlox)
	{
		FixedJoint2D[] fixedJoint2Ds = GetComponents<FixedJoint2D>();
		for (int i = 0; i < fixedJoint2Ds.Length; i++)
		{
			if (fixedJoint2Ds[i].connectedBody == fixJointBlox.RigidBody)
			{
				return;
			}
		}

		if (fixJointBlox.RigidBody != RigidBody)
		{
			FixedJoint2D thisFixedJoint2D = gameObject.AddComponent<FixedJoint2D>();
			thisFixedJoint2D.connectedBody = fixJointBlox.RigidBody;
			thisFixedJoint2D.connectedAnchor = fixJointBlox.transform.position;
			FixJoints.Add(thisFixedJoint2D);
		}
	}
}