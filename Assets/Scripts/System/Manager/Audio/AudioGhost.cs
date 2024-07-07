using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGhost : MonoBehaviour
{
    AudioSource _as;
    AudioSpawner _spawner;

    Transform _followTransform;
    Vector3 offset;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(_followTransform != null) transform.position = _followTransform.position + offset;
    }

    #region Play&Death
    public void PlaySound(AudioClip clip)
    {
        if (clip == null || _as == null) return;

        _as.clip = clip;
        _as.Play();

        StartCoroutine(PlayDuration(clip.length));
    }

    IEnumerator PlayDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        StopCoroutine(PlayDuration(duration));
        OnDeath();
    }

    void OnDeath()
    {
        if (_spawner == null) Debug.Log("AudioGhost: System not found");
        _spawner.GetGhost(this);
        TurnOff(this);
    }

    public void ForceDeath()
    {
        OnDeath();
    }
    #endregion

    #region Spawner Functions
    public static void TurnOn(AudioGhost e)
    {
        if(e != null) e.gameObject.SetActive(true);
    }

    public static void TurnOff(AudioGhost e)
    {
        e.gameObject.SetActive(false);
    }
    #endregion

    #region Setters
    public AudioGhost SetVolume(float vol)
    {
        //_as.volume = vol;
        //Debug.Log("Audio Ghost: Volume Set to " + _as.volume);
        return this;
    }

    public AudioGhost SetSpawner(AudioSpawner sp)
    {
        _spawner = sp;
        return this;
    }

    public AudioGhost SetTransform(Transform t)
    {
        this.SetTransform(t, Vector3.zero);

        return this;
    }

    public AudioGhost SetTransform(Transform t, Vector3 os)
    {
        _followTransform = t;

        if (os == null) os = new Vector3(0, 0, 0);
        offset = os;

        return this;
    }
    #endregion
}
