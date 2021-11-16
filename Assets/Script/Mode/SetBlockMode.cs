using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 블록 설치
public class SetBlockMode : MonoBehaviour
{
    new Camera camera;
    Transform cameraTf;

    [SerializeField]
    Object selectObject = null;

    [SerializeField]
    GameObject previewBlock;

    private void Start()
    {
        camera = Camera.main;
        cameraTf = camera.transform;
    }

    private void Update()
    {
        if (selectObject == null)
        {
            return;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ModeController.instance.GetLenght()));

        int posX = (int)(mousePos.x);
        int posY = (int)(mousePos.y);
        int posZ = (int)(mousePos.z);

        Vector3 tempPos = new Vector3(posX, posY, posZ);

        Vector3 direction = tempPos - cameraTf.position;

        RaycastHit hit;

        if (Physics.Raycast(cameraTf.position, direction, out hit))
        {
            tempPos = hit.transform.position + hit.normal;
        }

        previewBlock.transform.position = tempPos;

        if (Input.GetMouseButtonDown(1))
            setBlock(tempPos);
    }

    void setBlock(Vector3 pos)
    {
        if (!MapDataManager.instance.SetBlock(pos, selectObject))
        {
            Debug.Log("Fail Set Block");
            return;
        }

        GameObject block = GameObject.Instantiate(selectObject.prefab);

        block.transform.position = pos;
    }

    public void ChangeSelectBlock(Object obj)
    {
        selectObject = obj;

        if (obj == null)
            previewBlock.SetActive(false);
        else
            previewBlock.SetActive(true);
    }
}
