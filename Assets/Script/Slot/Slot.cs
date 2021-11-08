using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    protected Object obj;

    [SerializeField]
    protected Image icon;

    static protected GraphicRaycaster gr;

    void Start()
    {
        gr = SetBlockModeUIManager.instance.graphicRaycaster;
    }

    public virtual void SetSlot(Object i_obj)
    {
        obj = i_obj;

        icon.sprite = obj.icon;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (obj == null)
            return;

        SetBlockModeUIManager.instance.StartDrag(obj);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (obj == null)
            return;

        SetBlockModeUIManager.instance.Drag(eventData.position);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (obj == null)
            return;

        List<RaycastResult> results = new List<RaycastResult>();

        gr.Raycast(eventData, results);

        QuickSlot receiveSlot = null;

        foreach(RaycastResult result in results)
        {
            receiveSlot = result.gameObject.GetComponent<QuickSlot>();

            if (receiveSlot != null)
            {
                receiveSlot.SetSlot(obj);
                break;
            }
        }

        SetBlockModeUIManager.instance.EndDrag();
    }

    public Object GetObjectData()
    {
        return obj;
    }
}
