using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectableButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image selectableBorder;
    
    private SelectableButtonGroup _group;

    public void SetGroupParent(SelectableButtonGroup group)
    {
        _group = group;
        button.onClick.AddListener(() => { _group?.SetSelected(this); });
    }

    public void SetSelectedWithoutNotify(bool state)
    {
        selectableBorder.enabled = state;
    }

    public void AddListener(UnityAction call)
    {
        button.onClick.AddListener(call);
    }

    public void Select()
    {
        button.onClick.Invoke();
    }

    public void SetColor(Color color)
    {
        button.image.color = color;
    }

    public void SetSprite(Sprite thumb)
    {
        button.image.sprite = thumb;
    }
}
