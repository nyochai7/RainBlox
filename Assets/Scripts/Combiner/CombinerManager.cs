using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinerManager : MonoBehaviour
{
	[SerializeField] private List<CombinerSlot> combinerSlots;
	private IBox currentBlox = null;

	private void Awake()
	{
		InitializeCombinerSlots();
	}

	private void InitializeCombinerSlots()
	{
		for (int i = 0; i < combinerSlots.Count; i++)
		{
			combinerSlots[i].Position = i;
			combinerSlots[i].OnButtonMouseUp += OnMouseUpOnCombinerSlot;
		}
	}

	private void Update()
	{
		//if (Input.GetMouseButtonDown(0))
		//{
		//	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//	RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
		//	if (hit)
		//	{
		//		Debug.Log(hit.collider.gameObject.name);
		//	}
		//}
	}

	private void OnMouseUpOnCombinerSlot(int slotPosition)
	{
		//Debug.Log(slotPosition);
		if (currentBlox != null)
		{
			if (currentBlox.BloxSize <= GetNumberOfClearSlots())    //put the bloxes in the empty slots
			{
				int j = slotPosition;
				for (int i = 0; i < currentBlox.BloxSize; i++)
				{
					for (; j != slotPosition; j++)
					{
						if (j == combinerSlots.Count)
						{
							j = 0;
						}

						if (combinerSlots[j].Image == null)
						{
							SetBloxInUISlot(j);
							break;
						}
					}
				}
			}
		}
	}

	private void SetBloxInUISlot(int slotPosition)
	{
		//combinerSlots[slotPosition].Image = currentBlox.Image;
		combinerSlots[slotPosition].BloxLives = currentBlox.BloxLives;
	}

	private int GetNumberOfClearSlots()
	{
		int clearBloxCounter = 0;
		for (int i = 0; i < combinerSlots.Count; i++)
		{
			if (combinerSlots[i].Image == null)
			{
				clearBloxCounter++;
			}
		}

		return clearBloxCounter;
	}

   public void CombineSlots()
	{

	}

	private float GetAvarageBoxLives()
	{
		float boxLivesAverage = 0;
		for (int i = 0; i < combinerSlots.Count; i++)
		{
			if(combinerSlots[i].Image != null)
			{
				boxLivesAverage += combinerSlots[i].BloxLives;
			}
		}

		return boxLivesAverage / GetNumberOfClearSlots();
	}
}