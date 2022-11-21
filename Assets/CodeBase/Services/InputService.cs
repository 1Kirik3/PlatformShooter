﻿using Assets.CodeBase.Infrasctructure;
using UnityEngine;

public class InputService : IService
{
    private Vector3 _inputVector = Vector3.zero;
    public Vector3 MousePosition => Input.mousePosition;

    public Vector3 GetInputVector()
    {
        _inputVector.x = Input.GetAxis("Horizontal");
        _inputVector.z = Input.GetAxis("Vertical");
        return _inputVector;
    }

    public float GetJumpInput() 
        => _inputVector.y = Input.GetAxis("Jump");
    public bool GetShootButton() 
        => Input.GetMouseButtonDown(0);
}