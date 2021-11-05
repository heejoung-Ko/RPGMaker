using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlockMode : MonoBehaviour
{
    new Camera camera;
    Transform cameraTf;

    GameObject selectBlock;

    [SerializeField]
    GameObject previewBlock;

    private void Start()
    {
        camera = Camera.main;
        cameraTf = camera.transform;
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ModeController.instance.GetLenght()));

        int posX = (int)(mousePos.x);
        int posY = (int)(mousePos.y);
        int posZ = (int)(mousePos.z);

        Vector3 tempPos = new Vector3(posX, posY, posZ);

        Vector3 direction = tempPos - cameraTf.position;

        RaycastHit hit;

        selectBlock = null;

        if (Physics.Raycast(cameraTf.position, direction, out hit))
        {
            tempPos = hit.transform.position;
            selectBlock = hit.transform.gameObject;
        }

        if (selectBlock == null)
            previewBlock.SetActive(false);
        else
        {
            previewBlock.SetActive(true);
            previewBlock.transform.position = tempPos;
        }

        if (Input.GetMouseButtonDown(1))
            removeBlock();
    }

    void removeBlock()
    {
        if(selectBlock == null)
        {
            Debug.Log("No block to remove");
            return;
        }

        Destroy(selectBlock);
    }
}
