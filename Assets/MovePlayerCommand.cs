using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sources : https://www.youtube.com/watch?v=oLRINAn0cuw&ab_channel=iHeartGameDev
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
