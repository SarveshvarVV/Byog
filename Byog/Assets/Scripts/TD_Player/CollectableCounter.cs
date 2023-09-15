using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCounter : MonoBehaviour
{
    [SerializeField] int collectableCount = 0;
    [SerializeField] int maxCollectableCount = 5;
    public void AddCount()
    {
        if(collectableCount <= maxCollectableCount) 
        {
            collectableCount++;
            // update UI
        }
    }
}
