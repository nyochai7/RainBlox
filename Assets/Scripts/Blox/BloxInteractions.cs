using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloxInteractions : MonoBehaviour
{
	[SerializeField] private static FixJointBlox[] fixJointBloxs;

	private void Awake()
	{
		fixJointBloxs = FindObjectsOfType<FixJointBlox>();
	}

	public static void DisableRigidbodys()
	{
		FixJointBlox excludedFixJointBlox = MoveObject.CurrentMovingBlox;
		for (int i = 0; i < fixJointBloxs.Length; i++)
		{
			if (fixJointBloxs[i] != excludedFixJointBlox && fixJointBloxs[i].gameObject.tag == "blox")
			{
				EnableRigidbody(fixJointBloxs[i], false);
			}
		}
	}

	public static void EnableAllRigidbodys()
	{
		foreach (var item in fixJointBloxs)
		{
			EnableRigidbody(item, true);
		}
	}

	private static void EnableRigidbody(FixJointBlox fixJointBlox, bool isEnabled)
	{
		if (isEnabled)
		{
			fixJointBlox.RigidBody.bodyType = RigidbodyType2D.Dynamic;
			fixJointBlox.RigidBody.constraints = RigidbodyConstraints2D.None;
		}
		else
		{
			fixJointBlox.RigidBody.bodyType = RigidbodyType2D.Kinematic;
			fixJointBlox.RigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
			fixJointBlox.RigidBody.velocity = new Vector3(0, 0, 0);
		}
	}
}