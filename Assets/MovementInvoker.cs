using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sources https://www.youtube.com/watch?v=oLRINAn0cuw&ab_channel=iHeartGameDev
public class MovementInvoker
{
    //ICommand onCommand;
    Stack<ICommand> commandList;

    public MovementInvoker(/*ICommand oncommand*/) 
    {
        //onCommand = oncommand;
        commandList = new Stack<ICommand>();

    }


    public void ExecuteMovement()
    {
        //onCommand.Execute();
        
    }


    public void addCommand(ICommand newcommand)
    {
        newcommand.Execute();
        commandList.Push(newcommand);
    }

    public void UndoCommand()
    {
        ICommand latestcommand = commandList.Pop();
        latestcommand.Undo();
    }
}
