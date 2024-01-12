using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
//[RequireComponent(typeof(PlayerInput))]

public class runtimemovement : MonoBehaviour
{
    private movement input;
    private CharacterController controller;
    [SerializeField] private float fraction;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<movement>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        controller.Move(new Vector3((input.moveVal.x * input.moveSpeed) / fraction , 0f, (input.moveVal.y * input.moveSpeed) / fraction));
    }
}
