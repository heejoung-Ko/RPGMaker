using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// ī�޶� ȸ��
public class CameraRotate : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Transform cameraTF;

    [SerializeField, Range(0f, 100f)]
    float rotateSensitivity;    // ȸ�� ����

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

        cameraTF.rotation = Quaternion.Euler(xRotate, yRotate, 0);

        beginPos = eventData.position;
    }
}