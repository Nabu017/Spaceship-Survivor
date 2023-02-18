using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerCommand : ICommand
{
    PlayerMovement2 movement;
    PlayerMovement2 previousmovement;
    public MovePlayerCommand(PlayerMovement2 Movement)
    {
        movement = Movement;
        previousmovement = Movement.GetComponent<PlayerMovement2>();
    }
    
    public void Execute()
    {
        movement.Movement();
    }

    public void Undo()
    {
        movement = previousmovement;
    }
}
