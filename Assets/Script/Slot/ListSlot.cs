using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListSlot : Slot
{ 
    [SerializeField]
    Text id;

    public override void SetSlot(Object i_obj)
    {
        base.SetSlot(i_obj);
        id.text = obj.id;
    }
}
