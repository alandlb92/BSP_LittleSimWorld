using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class DialogData
{
    public DialogNode Dialog;
}

[Serializable]
public struct DialogNode
{
    public string text;
    public List<Answer> answers;
    public UnityEvent actions;
}

[Serializable]
public struct Answer
{
    public string text;
    public DialogNode dialog;
}