using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPuzzleElement : MonoBehaviour, IActivable
{
    public bool isActivated;
    [SerializeField] TorchPuzzleConverter converter;

    public void Trigger()
    {
        isActivated = !isActivated;
        converter.NotifyChange();
    }
}
