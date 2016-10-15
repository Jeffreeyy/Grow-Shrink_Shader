using UnityEngine;
using System.Collections;

public class PlayerPCInput : MonoBehaviour
{

    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

	void Update ()
    {
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _playerMovement.MoveLeft();
        }
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _playerMovement.MoveRight();
        }
    }
}
