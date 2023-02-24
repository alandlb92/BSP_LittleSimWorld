using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject _pivot;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SelectableButton _btnTemplate_reference;
    [SerializeField] private SelectableButtonGroup _btnGroup;

    [SerializeField] private int _maxCharactersPerPanel = 125;
    [Range(.02f, 1)]
    [SerializeField] private float _timeBetweenCharacters = .3f;

    public float TimeBetweenCharacters => _timeBetweenCharacters;
    public int MaxCharactersPerPanel => _maxCharactersPerPanel;

    public bool IsEnabled => _pivot.activeSelf;

    public void Show()
    {
        _pivot.SetActive(true);
    }

    public void Hide()
    {
        _pivot.SetActive(false);
    }

    public void ChangeText(string text)
    {
        _text.text = text;
    }

    public void ShowAnswers(List<Answer> answers, Action<Answer> p)
    {
        ChangeText("");
        _btnGroup.Clear();

        foreach (var answer in answers)
        {
            var btn = Instantiate(_btnTemplate_reference, _btnGroup.transform);
            btn.SetText(answer.text);
            btn.AddListener(() => { p.Invoke(answer); _btnGroup.Clear(); });
            _btnGroup.AddToGroup(btn);
        }

        if (answers.Count > 0)
            _btnGroup.SetAsSelectedByIndex(0);
    }
}
