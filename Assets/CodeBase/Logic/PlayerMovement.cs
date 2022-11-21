using Assets.CodeBase.Infrasctructure;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharacterController;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxAcceleration;
    [SerializeField] private float _groundAcceleration;
    [SerializeField] private float _controlMovement;


    private Vector3 _verticalVelocity;

    private InputService _inputService;

   

    private const float Gravity = -9.81f;

    private void Start()
    {
        _inputService = AllServices.Instance.GetService<InputService>();

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
