using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        foreach(Selectable selectableChild in gameObject.GetComponentsInChildren<Selectable>())
        {
            PointerEventData newEventData = eventData;
            newEventData.position = selectableChild.transform.position;
            selectableChild.OnPointerUp(newEventData);
        }      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (Selectable selectableChild in gameObject.GetComponentsInChildren<Selectable>())
        {
            PointerEventData newEventData = eventData;

            newEventData.position = selectableChild.transform.position;
            selectableChild.OnPointerDown(newEventData);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (Selectable selectableChild in gameObject.GetComponentsInChildren<Selectable>())
        {
            PointerEventData newEventData = eventData;

            newEventData.position = selectableChild.transform.position;
            selectableChild.OnPointerExit(newEventData);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (Selectable selectableChild in gameObject.GetComponentsInChildren<Selectable>())
        {
            PointerEventData newEventData = eventData;
            newEventData.position = selectableChild.transform.position;
            selectableChild.OnPointerEnter(newEventData);
        }
    }
}
