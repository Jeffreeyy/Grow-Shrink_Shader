using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float _movementSpeed;
    [SerializeField]private float _turnSpeed;
    [SerializeField]private float _gravity = 20.0F;
    private Vector3 _moveDirection;
    private CharacterController _cc;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    public void MoveLeft()
    {
        transform.Rotate(Vector3.down * _turnSpeed);
    }

    public void MoveRight()
    {
        transform.Rotate(Vector3.up * _turnSpeed);
    }

    void Update()
    {
        if (_cc.isGrounded)
        {
            _moveDirection = Vector3.forward;
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _movementSpeed;
        }
        _moveDirection.y -= _gravity * Time.deltaTime;
        _cc.Move(_moveDirection * Time.deltaTime);
    }
}
