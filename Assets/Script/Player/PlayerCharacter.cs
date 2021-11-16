using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    CharacterController characterController;

    Animator animator;
    
    [SerializeField]
    float moveSpeed;    // 속도
    [SerializeField]
    float accelerationSpeed;    // 가속도
    float presentMoveSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();

        presentMoveSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(direction == Vector3.zero)
        {
            presentMoveSpeed = 0;

            animator.SetFloat("MoveSpeed", presentMoveSpeed / moveSpeed);

            return;
        }

        presentMoveSpeed = Mathf.Clamp(presentMoveSpeed + (accelerationSpeed * Time.deltaTime), 0f, moveSpeed);

        direction *= presentMoveSpeed * Time.deltaTime;

        animator.SetFloat("MoveSpeed", presentMoveSpeed / moveSpeed);

        characterController.Move(direction);
    }
}
