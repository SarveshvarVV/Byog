using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour,Interactables
{
    [SerializeField] Dialog dialog;
    public void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);

    }

}