using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Close = Animator.StringToHash("Close");

    public void OpenDoor()
    {
        _animator.SetTrigger(Open);
    }

    public void CloseDoor()
    {
        _animator.SetTrigger(Close);

    }
}
