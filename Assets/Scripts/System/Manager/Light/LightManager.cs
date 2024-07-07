using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    Pool<LightGhost> _pool;
    LightGhost prefab;

    static LightManager _instance;
    public static LightManager Instance { get { return _instance; } private set { } }

    #region SetUp
    private void Awake()
    {
        _instance = this;

        prefab = Resources.Load<LightGhost>("LightGhost");
        AudioSystem.RefreshDictionary();
    }

    protected virtual void Start()
    {
        _pool = new Pool<LightGhost>(Factory, LightGhost.TurnOn, LightGhost.TurnOff, 1, true);
    }
    #endregion

    #region Spawning
    public LightGhost CallLight(Transform t, Vector3 offset)
    {
        Transform tempTrans = t;
        if (tempTrans == null) return null;

        Vector3 tempOffset = offset;
        if (offset == null) offset = Vector3.zero;

        var a = _pool.SendFromPool();

        a.SetSpawner(this)
         .SetTransform(tempTrans)
         .SetOffset(tempOffset);

        return a;
    }
    #endregion

    #region SpawnOptions
    protected Vector3 safezone = new Vector3(-1000, -1000, -1000);
    public LightGhost Factory()
    {
        if (prefab == null) return null;

        var temp = Instantiate(prefab);
        temp.transform.position = safezone;
        return temp;
    }

    public void GetGhost(LightGhost lg)
    {
        _pool.ReturnToPool(lg);
    }
    #endregion
}
