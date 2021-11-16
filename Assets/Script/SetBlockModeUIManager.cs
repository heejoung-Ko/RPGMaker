using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBlockModeUIManager : MonoBehaviour
{
    public static SetBlockModeUIManager instance;

    Canvas canvas;
    public GraphicRaycaster graphicRaycaster;

    [SerializeField]
    GameObject dragSlot;
    RectTransform dragSlotRF;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }

        canvas = transform.root.GetComponentInChildren<Canvas>();
        graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();

        dragSlotRF = dragSlot.GetComponent<RectTransform>();
    }

    public void StartDrag(Object obj)
    {
        dragSlot.GetComponent<Slot>().SetSlot(obj);
        dragSlot.SetActive(true);
    }

    public void Drag(Vector2 pos)
    {
        pos -= new Vector2(canvas.renderingDisplaySize.x / 2, canvas.renderingDisplaySize.y / 2);
        dragSlotRF.anchoredPosition = pos;
    }

    public void EndDrag()
    {
        dragSlot.SetActive(false);
    }

    public Object DropDrag()
    {
        return dragSlot.GetComponent<Slot>().GetObjectData();
    }
}
