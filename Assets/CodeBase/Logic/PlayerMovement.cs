using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharacterController;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private InputService _inputService;
    private Vector3 _verticalVelocity;

    private const float Gravity = -9.81f;

    private void Start()
    {
        _inputService = new InputService();
        _verticalVelocity = Vector3.up;
    }

    private void Update()
    {
        Vector3 inputVector = GetInputVector();
        Jump();
        MovePlayer(inputVector * _speed);
        MovePlayer(_verticalVelocity);
    }
    private void ApplyGravity()
    {
        if (CharacterController.isGrounded == false)
            _verticalVelocity.y += Gravity * Time.deltaTime;
    }

    private void Jump()
    {   if (CharacterController.isGrounded)
            if (_inputService.GetJumpInput() > 0)
                _verticalVelocity.y = _inputService.GetJumpInput() * _jumpForce;
            else
                _verticalVelocity.y += 0;
        else
            ApplyGravity();
    }

    private void MovePlayer(Vector3 movement) 
        => CharacterController.Move(movement * Time.deltaTime);

    private Vector3 GetInputVector()
        => _inputService.GetInputVector();
}
