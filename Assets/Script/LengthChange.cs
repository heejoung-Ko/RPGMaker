using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LengthChange : MonoBehaviour
{
    Slider slider;

    [SerializeField]
    Text lengthValue;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void OnDisable()
    {
        float length = ModeController.instance.GetLenght();
        slider.value = ModeController.instance.GetNomalizedLength();
        lengthValue.text = length.ToString();
    }

    private void Update()
    {
        if (0 < Input.GetAxis("Mouse ScrollWheel"))
        {
            slider.value -= Time.deltaTime;
            ChangeLength();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            slider.value += Time.deltaTime;
            ChangeLength();
        }
    }

    public void ChangeLength()
    {
        ModeController.instance.ChangeLength(slider.value);
        lengthValue.text = ModeController.instance.GetLenght().ToString();
    }
}
