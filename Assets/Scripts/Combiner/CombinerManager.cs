using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinerManager : MonoBehaviour
{
	[SerializeField] private GameObject boxManagerPrefab;
	[SerializeField] private List<CombinerSlot> combinerSlots;
	[SerializeField] private List<BoxCollider2D> combinerSlotColliders;

	private void Awake()
	{
		InitializeCombinerSlots();
	}

	private void InitializeCombinerSlots()
	{
		combinerSlotColliders = new List<BoxCollider2D>();

		for (int i = 0; i < combinerSlots.Count; i++)
		{
			combinerSlots[i].Position = i;
			combinerSlots[i].OnButtonMouseUp += OnMouseUpOnCombinerSlot;
			BoxCollider2D collider = combinerSlots[i].GetComponent<BoxCollider2D>();
			combinerSlotColliders.Add(collider);
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			for (int i = 0; i < combinerSlotColliders.Count; i++)
			{
				if (combinerSlotColliders[i].bounds.Contains(Input.mousePosition))
				{
					OnMouseUpOnCombinerSlot(i);
					break;
				}
			}
		}
	}

	private void OnMouseUpOnCombinerSlot(int slotPosition)
	{
		Debug.Log(slotPosition);
		if (MoveObject.CurrentMovingBlox != null)
		{
			IBlox currentBlox = MoveObject.CurrentMovingBlox.GetComponent<IBlox>();
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

						if (combinerSlots[j].Image.sprite == null)
						{
							SetBloxInUISlot(currentBlox, j);
							break;
						}
					}
				}
			}
		}
	}

	private void SetBloxInUISlot(IBlox currentBlox, int slotPosition)
	{
		combinerSlots[slotPosition].Image.sprite = currentBlox.Sprite;
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
		float averageBoxLives = GetAvarageBoxLives();
		int size = combinerSlots.Count - GetNumberOfClearSlots();
		ClearCombineSlots();
		EnableSlots(false);
		CreateNewBlox(averageBoxLives, size);
	}

	private void ClearCombineSlots()
	{
		for (int i = 0; i < combinerSlots.Count; i++)
		{
			combinerSlots[i].Image = null;
			combinerSlots[i].BloxLives = 0;
		}
	}

	private void CreateNewBlox(float averageBoxLives, int size)
	{
		Instantiate<GameObject>(boxManagerPrefab, combinerSlots[(int)(combinerSlots.Count / 2)].transform);
	}

	private void EnableSlots(bool isEnabled)
	{
		for (int i = 0; i < combinerSlots.Count; i++)
		{
			combinerSlots[i].gameObject.SetActive(isEnabled);
		}
	}

	private float GetAvarageBoxLives()
	{
		float boxLivesAverage = 0;
		for (int i = 0; i < combinerSlots.Count; i++)
		{
			if(combinerSlots[i].Image.sprite != null)
			{
				boxLivesAverage += combinerSlots[i].BloxLives;
			}
		}

		return boxLivesAverage / GetNumberOfClearSlots();
	}
}