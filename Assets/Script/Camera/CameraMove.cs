using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라 이동
public class CameraMove : MonoBehaviour
{
    [SerializeField, Range(0, 100f)]
    float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        Vector3 forward = transform.forward;
        forward.y = 0;
        Vector3 right = transform.right;
        right.y = 0;

        Vector3 moveDirection =
         forward * Input.GetAxis("Vertical") +
         right * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
            moveDirection.y += 1;
        if(Input.GetKey(KeyCode.LeftShift))
            moveDirection.y -= 1;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
