using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 블록 설치
public class SetBlockMode : MonoBehaviour
{
    new Camera camera;
    Transform cameraTf;

    [SerializeField]
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
        GameObject block = GameObject.Instantiate(selectBlock);

        block.transform.position = pos;
    }

    // private void OnDrawGizmos()
    // {
    //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, lenght));
    // 
    //     Vector3 direction = mousePos - cameraTf.position;
    // 
    //     Gizmos.color = Color.red;
    // 
    //     int posX = (int)(mousePos.x); 
    //     int posY = (int)(mousePos.y);
    //     int posZ = (int)(mousePos.z);
    // 
    //     Vector3 temp = new Vector3(posX, posY, posZ);
    // 
    //     Gizmos.DrawRay(cameraTf.position, direction);
    // 
    // }
}
