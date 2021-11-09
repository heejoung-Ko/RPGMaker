using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 카메라 회전
public class CameraRotate : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Transform cameraTF;

    [SerializeField, Range(0f, 100f)]
    float rotateSensitivity;    // 회전 감도

    Vector3 beginPos;

    private void Start()
    {
        cameraTF = Camera.main.transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(1)) return;

        float tempPosX = eventData.position.x - beginPos.x;
        float tempPosY = eventData.position.y - beginPos.y;

        float xRotate = cameraTF.eulerAngles.x + tempPosY * rotateSensitivity * Time.deltaTime;
        float yRotate = cameraTF.eulerAngles.y + tempPosX * rotateSensitivity * Time.deltaTime;

        xRotate = (xRotate + 360) % 360;

        if (269f < xRotate)
            xRotate = Mathf.Clamp(xRotate, 280f, 360f);
        else if(xRotate < 91f)
            xRotate = Mathf.Clamp(xRotate, 0f, 80f);

        Debug.Log(xRotate);

        cameraTF.rotation = Quaternion.Euler(xRotate, yRotate, 0);

        beginPos = eventData.position;
    }
}
