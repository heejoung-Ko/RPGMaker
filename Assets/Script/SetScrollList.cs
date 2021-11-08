using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScrollList : MonoBehaviour
{
    [SerializeField]
    Transform contentTF;

    [SerializeField]
    GameObject slotFreeSet;

    void Start()
    {
        List<Object> objList = DataManager.instance.BlockList;

        foreach(Object obj in objList)
        {
            GameObject slot = Instantiate(slotFreeSet, contentTF);
            slot.GetComponent<ListSlot>().SetSlot(obj);
        }

        setContentSize(objList.Count);
    }

    void setContentSize(int objectNum)
    {
        RectTransform contentRF = contentTF.GetComponent<RectTransform>();
        GridLayoutGroup gridLayout = contentTF.GetComponent<GridLayoutGroup>();

        int lineNum = (objectNum - 1) / gridLayout.constraintCount + 1;

        float newHeight = 0;

        newHeight += gridLayout.padding.top;
        newHeight += gridLayout.padding.bottom;

        newHeight += gridLayout.cellSize.y * lineNum;

        newHeight += gridLayout.spacing.y * (lineNum - 1);

        contentRF.sizeDelta = new Vector2(contentRF.sizeDelta.x, newHeight);
    }
}
