using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain
{
    PlayerController _pc;
    Keybinds _keybinds;

    Dictionary<KeyCode, ICommand> _commands = new Dictionary<KeyCode, ICommand>();

    #region SetUp
    public PlayerBrain(PlayerController pc)
    {
        _pc = pc;
        RefreshKeybinds();
    }

    void RefreshKeybinds()
    {
        _commands.Add(KeyValues.Keyboard.interact, new EmptyCommand());
    }
    #endregion

    void Listener()
    {
        Executes();
    }

    void Executes()
    {
        foreach (var command in _commands)
        {
            if (Input.GetKey(command.Key))
                command.Value.OnEnter();
        }
        /*
        foreach (var command in _commands)
        {
            if (Input.GetKeyDown(command.Key))
                command.Value.Execute();
        }
        foreach (var command in _commands)
        {
            if (Input.GetKeyUp(command.Key))
                command.Value.OnExit();
        }*/
    }
}
