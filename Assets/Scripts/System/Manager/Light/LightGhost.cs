using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGhost : MonoBehaviour
{
    Light _light;
    LightManager _spawner;

    Transform _followTransform;
    Vector3 offset;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        if (_followTransform != null) transform.position = _followTransform.position + offset;
    }

    #region Death   
    public void ReturnLight()
    {
        if (_spawner == null) Debug.Log("LightGhost: System not found");
        _spawner.GetGhost(this);
        TurnOff(this);
    }
    #endregion

    #region Spawner Functions
    public static void TurnOn(LightGhost e)
    {
        e.gameObject.SetActive(true);
    }

    public static void TurnOff(LightGhost e)
    {
        e.gameObject.SetActive(false);
    }
    #endregion

    #region Setters
    public LightGhost SetSpawner(LightManager sp)
    {
        _spawner = sp;
        return this;
    }

    public LightGhost SetTransform(Transform t)
    {
        _followTransform = t;

        return this;
    }

    public LightGhost SetOffset(Vector3 off)
    {
        offset = off;

        return this;    
    }
    #endregion
}
