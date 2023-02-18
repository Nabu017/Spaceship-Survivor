using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnabler : MonoBehaviour
{
   [SerializeField] public PlayerMovement2 playermovement;

    MovementInvoker movementInvoker;

    
    // Start is called before the first frame update
    void Start()
    {
        //ICommand moveplayercommand = new MovePlayerCommand(playermovement);
        movementInvoker = new MovementInvoker();
    }

    // Update is called once per frame
    void Update()
    {
        ICommand command = new MovePlayerCommand(playermovement);
        movementInvoker.addCommand(command);


        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("undo called");
            movementInvoker.UndoCommand();
        }
    }
}
