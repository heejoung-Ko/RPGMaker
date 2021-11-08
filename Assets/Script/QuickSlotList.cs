using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuickSlotList : MonoBehaviour
{
    [SerializeField]
    GameObject slotFreeSet;

    List<QuickSlot> quickSlotList;

    int selectSlotIndex;

    private void Start()
    {
        quickSlotList = new List<QuickSlot>();

        for (int i = 0; i < 9; i++)
        {
            GameObject slot = Instantiate(slotFreeSet, transform);
            QuickSlot quickSlot = slot.GetComponent<QuickSlot>();

            quickSlot.SetIndex(i + 1);
            quickSlot.SetSelect(false);

            quickSlotList.Add(quickSlot);
        }

        selectSlotIndex = 0;
        quickSlotList[selectSlotIndex].SetSelect(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            changeSelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            changeSelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            changeSelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            changeSelectSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            changeSelectSlot(4);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            changeSelectSlot(5);
        if (Input.GetKeyDown(KeyCode.Alpha7))
            changeSelectSlot(6);
        if (Input.GetKeyDown(KeyCode.Alpha8))
            changeSelectSlot(7);
        if (Input.GetKeyDown(KeyCode.Alpha9))
            changeSelectSlot(8);
    }

    void changeSelectSlot(int index)
    {
        if (selectSlotIndex == index)
            return;

        quickSlotList[selectSlotIndex].SetSelect(false);

        selectSlotIndex = index;

        quickSlotList[selectSlotIndex].SetSelect(true);

        Object obj = quickSlotList[selectSlotIndex].GetObjectData();

        ModeController.instance.ChangeSelectSlot(obj);
    }
}
