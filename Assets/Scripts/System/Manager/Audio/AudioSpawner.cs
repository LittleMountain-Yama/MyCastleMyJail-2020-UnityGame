using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpawner : MonoBehaviour
{
    Pool<AudioGhost> _pool;
    AudioGhost prefab;

    #region SetUp
    private void Awake()
    {
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Audio_CallSound, CallAudio);

        prefab = Resources.Load<AudioGhost>("AudioGhost");
        AudioSystem.RefreshDictionary();
    }

    protected virtual void Start()
    {
        _pool = new Pool<AudioGhost>(Factory, AudioGhost.TurnOn, AudioGhost.TurnOff, 1, true);
    }
    #endregion

    //Tenemos que pedir transform y clip
    void CallAudio(params object[] param)
    {
        //Debug.Log("AudioSystem: CallAudio Executed");

        Transform tempTrans = (Transform)param[0];
        if (tempTrans == null) return;

        var a = _pool.SendFromPool();

        a.SetSpawner(this)
         .SetTransform(tempTrans)
         .SetVolume(Volume.GetEffectValue());

        a.PlaySound((AudioClip)param[1]);
    }

    #region SpawnOptions
    protected Vector3 safezone = new Vector3(-1000, -1000, -1000);
    public AudioGhost Factory()
    {
        if (prefab == null) return null;

        var temp = Instantiate(prefab);
        temp.transform.position = safezone;
        return temp;
    }

    public void GetGhost(AudioGhost ag)
    {
        _pool.ReturnToPool(ag);
    }
    #endregion
}
