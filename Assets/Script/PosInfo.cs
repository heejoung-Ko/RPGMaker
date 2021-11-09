using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosInfo : MonoBehaviour
{
    [SerializeField]
    Text posX;

    [SerializeField]
    Text posY;

    [SerializeField]
    Text posZ;

    Transform cameraTf;

    private void Start()
    {
        cameraTf = Camera.main.transform;
    }

    private void Update()
    {
        posX.text = cameraTf.position.x.ToString();
        posY.text = cameraTf.position.y.ToString();
        posZ.text = cameraTf.position.z.ToString();
    }
}
