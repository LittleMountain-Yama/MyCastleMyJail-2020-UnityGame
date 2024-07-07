using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyValues : MonoBehaviour
{
    public static readonly Keybinds Keyboard = new Keybinds
    {
        interact = KeyCode.F,        
    };

    public static readonly Keybinds Custom = new Keybinds { };
}
