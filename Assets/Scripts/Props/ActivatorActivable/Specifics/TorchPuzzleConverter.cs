using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPuzzleConverter : MonoBehaviour, IActivator
{
    [SerializeField] List<TorchPuzzleElement> torches = new List<TorchPuzzleElement>();
    [SerializeField] GameObject activable;   

    void Awake()
    {
        NotifyChange();
    }

    [SerializeField] int count;
    public void NotifyChange()
    {
       count = 0;

       foreach (TorchPuzzleElement element in torches)
       {
            if(element.isActivated)
            {
                count++;
            }
       }

       if (count == torches.Count) SendSignal();
    }

    public void SendSignal()
    {
        var temp = activable.gameObject.GetComponent<IActivable>();

        if (activable != null || temp != null)
        {
            AudioSystem.PlaySound(AudioSystem.SoundType.Puzzle_Completed, this.transform);
            temp.Trigger();           
        }
    }
}
