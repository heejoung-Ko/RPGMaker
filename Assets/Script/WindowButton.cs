using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowButton : MonoBehaviour
{
    [SerializeField]
    GameObject window;

    public void OnClick()
    {
        window.SetActive(!window.activeSelf);
    }
}
