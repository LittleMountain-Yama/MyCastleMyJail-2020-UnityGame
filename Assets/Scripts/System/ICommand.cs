using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void OnEnter();

    void Execute();

    void OnExit();
}

public class EmptyCommand : ICommand
{
    public void OnEnter(){}

    public void Execute(){}

    public void OnExit(){}
}
