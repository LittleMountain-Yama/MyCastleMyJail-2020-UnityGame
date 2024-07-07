using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem
{
    static Dictionary<SoundType, AudioClip> clips;

    public enum SoundType
    {
        //Player        

        //Props
        Item_PickUp,

        Lever_Activated,
        Chain_Break,

        Puzzle_Completed,

        Text_Trigger,
    }

    public static void PlaySound(SoundType sound, Transform t)
    {
        AudioClip tempSound = clips[sound];
        EventManager.TriggerEvent(EventManager.EventsType.Event_Audio_CallSound, t, tempSound);
    }

    public static void RefreshDictionary()
    {
        clips = new Dictionary<SoundType, AudioClip>();
        clips.Add(SoundType.Item_PickUp, Resources.Load<AudioClip>("Sounds/PickUp"));

        clips.Add(SoundType.Lever_Activated, Resources.Load<AudioClip>("Sounds/lever"));
        clips.Add(SoundType.Chain_Break, Resources.Load<AudioClip>("Sounds/Metal"));

        clips.Add(SoundType.Puzzle_Completed, Resources.Load<AudioClip>("Sounds/unlock"));

        clips.Add(SoundType.Text_Trigger, Resources.Load<AudioClip>("Sounds/page"));
    }
}
