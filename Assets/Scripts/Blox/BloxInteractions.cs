using UnityEngine;

public class BloxInteractions : MonoBehaviour
{
	public static void DisableRigidbodys()
	{
        return;
		FixJointBlox[] fixJointBloxs = FindObjectsOfType<FixJointBlox>();
		for (int i = 0; i < fixJointBloxs.Length; i++)
		{
			if (fixJointBloxs[i] != MoveObject.CurrentMovingBlox && fixJointBloxs[i].gameObject.tag == "blox")
			{
				EnableRigidbody(fixJointBloxs[i], false);
			}
		}
	}

	public static void EnableAllRigidbodys()
	{
        return;
		FixJointBlox[] fixJointBloxs = FindObjectsOfType<FixJointBlox>();
		foreach (var item in fixJointBloxs)
		{
			EnableRigidbody(item, true);
		}
	}

	private static void EnableRigidbody(FixJointBlox fixJointBlox, bool isEnabled)
	{
        if (fixJointBlox.RigidBody.bodyType == RigidbodyType2D.Static) return;

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