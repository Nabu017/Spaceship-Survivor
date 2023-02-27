using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
//sources : https://www.youtube.com/watch?v=oLRINAn0cuw&ab_channel=iHeartGameDev
public class MovementEnabler : MonoBehaviour
{
   [SerializeField] public PlayerMovement2 playermovement;

    //[Inject]
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
