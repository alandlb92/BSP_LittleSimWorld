using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public struct DialogEvent
{
    public DialogEventType type;
    public int intParam;
}

[Serializable]
public enum DialogEventType
{
    NONE = 0,
    GIVE_MONEY_TO_OTHER = 1,
    ADD_MONEY_SELF = 2,
    OPEN_STORE = 3
}

[Serializable]
public class DialogData
{
    public DialogNode Dialog;
    public Action<DialogEvent> EventMaster;
}

[Serializable]
public class DialogNode
{
    public string text;
    public List<Answer> answers;
    public DialogEvent Event;
    //public UnityEvent actions; this version of unity have problemas with nested events
}

[Serializable]
public class Answer
{
    public string text;
    public DialogNode dialog;
}