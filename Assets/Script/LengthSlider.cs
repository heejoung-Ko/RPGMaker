using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LengthSlider : MonoBehaviour
{
    Slider slider;

    [SerializeField]
    Text lengthValue;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void OnEnable()
    {
        lengthValue.text = ModeController.instance.GetLenght().ToString();
    }

    public void ChangeLength()
    {
        ModeController.instance.ChangeLength(slider.value);
        lengthValue.text = ModeController.instance.GetLenght().ToString();
    }
}
