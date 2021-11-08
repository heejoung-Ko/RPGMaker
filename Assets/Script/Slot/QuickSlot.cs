using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuickSlot : Slot
{
    [SerializeField]
    Text index;

    [SerializeField]
    GameObject selectMark;
    
    public void SetIndex(int i)
    {
        index.text = i.ToString();

        icon.gameObject.SetActive(false);
    }

    public override void SetSlot(Object i_obj)
    {
        if(i_obj == null)
        {
            obj = null;
            icon.gameObject.SetActive(false);
            return;
        }

        base.SetSlot(i_obj);
        icon.gameObject.SetActive(true);
        if(selectMark.activeSelf)
            ModeController.instance.ChangeSelectSlot(obj);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        icon.gameObject.SetActive(false);

        base.OnBeginDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (obj == null)
            return;

        List<RaycastResult> results = new List<RaycastResult>();

        gr.Raycast(eventData, results);

        QuickSlot receiveSlot = null;

        foreach (RaycastResult result in results)
        {
            receiveSlot = result.gameObject.GetComponent<QuickSlot>();

            if (receiveSlot != null)
            {
                Object tempObj = receiveSlot.GetObjectData();
                receiveSlot.SetSlot(obj);
                SetSlot(tempObj);
                break;
            }
        }

        if (obj != null)
            icon.gameObject.SetActive(true);

        SetBlockModeUIManager.instance.EndDrag();
    }

    public void SetSelect(bool isSelect)
    {
        selectMark.SetActive(isSelect);
    }
}
