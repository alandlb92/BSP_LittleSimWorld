using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectableButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _selectableBorder;
    [SerializeField] private TMP_Text _text;
    
    private SelectableButtonGroup _group;
    public void SetGroupParent(SelectableButtonGroup group)
    {
        _group = group;
        _button.onClick.AddListener(() => { _group?.SetSelected(this); });
    }

    public void SetSelectedWithoutNotify(bool state)
    {
        _selectableBorder.enabled = state;
        _button.Select();
    }

    public void AddListener(UnityAction call)
    {
        _button.onClick.AddListener(call);
    }

    public void Select()
    {
        _button.Select();
        _button.onClick.Invoke();
    }

    public void SetColor(Color color)
    {
        _button.image.color = color;
    }

    public void SetSprite(Sprite thumb)
    {
        _button.image.sprite = thumb;
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
