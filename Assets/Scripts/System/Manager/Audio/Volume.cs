using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume
{
    static float music = 0.5f, effect = 0.5f;

    public static void SetMusicValue(float v)
    {
        music = v;
    }

    public static float GetMusicValue()
    {
        return music;
    }

    public static void SetEffectValue(float v)
    {
        effect = v;
    }

    public static float GetEffectValue()
    {
        return effect;
    }
}
