using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CombinerSlot : MonoBehaviour//, /*IPointerClickHandler,*/ /*IPointerUpHandler*///, IPointerDownHandler
{
	public int Position { get; set; }
	public Image Image { get; set; }
	public int BloxLives { get; set; }
	public UnityAction<int> OnButtonMouseUp;

	//public void OnPointerClick(PointerEventData eventData)
	//{
	//	if (eventData.button == PointerEventData.InputButton.Left)
	//		Debug.Log(Position);
	//}

	//public void OnPointerUp(PointerEventData eventData)
	//{
	//	if (eventData.button == PointerEventData.InputButton.Left)
	//	{
	//		if (OnButtonMouseUp != null)
	//		{
	//			OnButtonMouseUp.Invoke(Position);
	//		}
	//	}
	//}

	//public void OnPointerDown(PointerEventData eventData)
	//{
	//}
}