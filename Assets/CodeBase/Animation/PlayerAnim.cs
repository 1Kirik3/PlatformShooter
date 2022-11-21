using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _animator.SetBool("isRunning", true);
        if (Input.GetKeyUp(KeyCode.W))
            _animator.SetBool("isRunning", false);
        if (Input.GetKeyDown(KeyCode.S))
            _animator.SetBool("isStepBack", true);
        if (Input.GetKeyUp(KeyCode.S))
            _animator.SetBool("isStepBack", false);
    }
}
