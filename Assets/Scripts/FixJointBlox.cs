using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixJointBlox : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rigidBody2D;
	[SerializeField] private AnchoredJoint2D fixJoint2D;

	private void OnCollisionEnter(Collision collision)
	{
		//FixJointBlox fixedJoint2D = collision.gameObject.GetComponent<FixJointBlox>();
		//if (fixedJoint2D != null)
		//{
		//	fixJoint2D.connectedBody = fixedJoint2D.rigidBody2D;
		//	fixedJoint2D.fixJoint2D.connectedBody = rigidBody2D;
		//}
	}
}