using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private GameControls _inputActions;
    private CharacterController _characterControl;

    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private Vector3 _charaVelocity;

    [Header("Movement Values")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity;

    [Header("Look Valyes")]
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private float _lookSpeed = 1f;
    [SerializeField] private float _maxLookDistance = 75f;
    private float _verticalLookRotation = 0f;

    private void Awake()
    {
        _characterControl = GetComponent<CharacterController>();
        _inputActions = new GameControls();

        _inputActions.Player.Move.performed +=
            context => _moveInput = context.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled +=
            context => _moveInput = Vector2.zero;

        _inputActions.Player.Look.performed +=
            context => _lookInput = context.ReadValue<Vector2>();
        _inputActions.Player.Look.canceled +=
            context => _lookInput = Vector2.zero;

        _inputActions.Player.Jump.performed +=
            context => Jump();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    private void Update()
    {
        MoveCharacter();
        PlayerLook();
    }

    public void EnableCharacter(bool enable)
    {
        if (enable)
        {
            _inputActions.Enable();
        }
        else
        {
            _inputActions.Disable();
        }
    }

    private void Jump()
    {
        if (_characterControl.isGrounded)
        {
            _charaVelocity.y = Mathf.Sqrt(_jumpHeight);
        }
    }

    private void PlayerLook()
    {
        float mouseX = _lookInput.x * _lookSpeed;
        float mouseY = _lookInput.y * _lookSpeed;

        transform.Rotate(Vector3.up * mouseX);

        _verticalLookRotation -= mouseY;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -_maxLookDistance, _maxLookDistance);
        _playerCamera.localRotation = Quaternion.Euler(_verticalLookRotation, 0f, 0f);
    }

    private void MoveCharacter()
    {
        Vector3 moveDirection = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        Vector3 horizontalVelocity = moveDirection * _speed;

        if (_characterControl.isGrounded)
        {
            if (_charaVelocity.y < 0)
                _charaVelocity.y = -2f;
        }
        else
        {
            _charaVelocity.y += _gravity * Time.deltaTime;
        }

        Vector3 finalVelocity = horizontalVelocity + _charaVelocity;
        _characterControl.Move(finalVelocity * Time.deltaTime);
    }
}
