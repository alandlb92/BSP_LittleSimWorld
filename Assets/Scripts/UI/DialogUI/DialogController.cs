using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : IDialog
{
    public DialogUI _ui;
    private IGameplayInput _iPlayerInput;

    private Action<DialogEvent> dialogEventMaster;

    private DialogNode _currentDialogNode;
    private Coroutine _currentDialogRoutine;

    private float _timeBetweenChar;
    private bool pause;

    public DialogController(DialogUI _gameObjectInstance, IGameplayInput playerInput)
    {
        _ui = _gameObjectInstance;
        _iPlayerInput = playerInput;
        _ui.Hide();
    }

    public void ShowDialog(DialogData dialog)
    {
        dialogEventMaster = dialog.EventMaster;
        _iPlayerInput.DisableInput();
        _ui.Show();
        ShowDialog(dialog.Dialog);
    }

    private void CloseDialog()
    {
        _ui.Hide();
        _iPlayerInput.EnableInput();
    }

    private void ShowDialog(DialogNode node)
    {
        _currentDialogNode = node;
        _currentDialogRoutine = _ui.StartCoroutine(DialogRotine());
    }

    public void Update()
    {
        if (!_ui.IsEnabled)
            return;

        if (pause && Input.GetButtonDown("Submit"))
            pause = false;
        else if (Input.GetButtonDown("Submit"))
            _timeBetweenChar = 0;
    }

    private IEnumerator DialogRotine()
    {
        dialogEventMaster.Invoke(_currentDialogNode.Event);
        string toPrint = "";
        void AddCharAndPrint(char c)
        {
            toPrint += c;
            _ui.ChangeText(toPrint);
        }

        void Clear()
        {
            toPrint = "";
            _ui.ChangeText(toPrint);
            _timeBetweenChar = _ui.TimeBetweenCharacters;
        }

        string[] words = _currentDialogNode.text.Split(" ");
        int countCharacters = 0;
        _ui.ChangeText(toPrint);
        _timeBetweenChar = _ui.TimeBetweenCharacters;

        if (_currentDialogNode.text.Length > 0)
            for (int i = 0; i < words.Length; i++)
            {
                foreach (char c in words[i])
                {
                    AddCharAndPrint(c);
                    countCharacters++;
                    yield return new WaitForSeconds(_timeBetweenChar);
                }

                AddCharAndPrint(' ');
                countCharacters++;

                if (i + 1 < words.Length && (words[i + 1].Length + countCharacters) >= _ui.MaxCharactersPerPanel)
                {
                    yield return Pause();
                    Clear();
                }
                else if (i + 1 >= words.Length)
                {
                    yield return Pause();
                    Clear();
                }
            }

        Answer answerChoose = null;
        if (_currentDialogNode.answers != null && _currentDialogNode.answers.Count > 0)
        {
            _ui.ShowAnswers(_currentDialogNode.answers, (answer) =>
            {
                pause = false;
                answerChoose = answer;
            });

            yield return Pause();
        }

        if (answerChoose?.dialog != null)
            ShowDialog(answerChoose.dialog);
        else
            CloseDialog();
    }

    private IEnumerator Pause()
    {
        yield return new WaitForEndOfFrame();
        pause = true;
        while (pause)
            yield return null;
    }


}
