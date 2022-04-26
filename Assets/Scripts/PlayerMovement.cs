using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    /*[SerializeField] InputActionAsset playerControls;
    InputActionAsset movement;

    CharacterController character;

    //Movement vector/player direction
    Vector3 moveVector;
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        //Find the Action Map then Inside the map grab a list of actions
        var gameplayActionMap = playerControls.FindActionMap("Default");

        movement = gameplayActionMap.FindAction("Move");
        movement.performed += OnMovementChanged;
        movement.canceled += OnMovementChanged;
        movement.Enable();

        character = GetComponents<CharacterController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        character.Move(moveVector * speed * Time.fixedDeltaTime);
    }

    private void OnMovementChanged(InputAction.CallbackContext context) 
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.x);

    }*/
}
