using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableButtonGroup : MonoBehaviour
{
    private List<SelectableButton> mSelectableButtons = new List<SelectableButton>();

    public void AddToGroup(SelectableButton btn)
    {
        mSelectableButtons.Add(btn);
        btn.SetGroupParent(this);
    }

    public void SetSelected(SelectableButton btn)
    {
        foreach (SelectableButton button in mSelectableButtons)
        {
            button.SetSelectedWithoutNotify(btn == button);
        }
    }

    public void SelectByIndex(int ind)
    {
        mSelectableButtons[ind].Select();
    }

    public void SetAsSelectedByIndex(int ind)
    {
        for (int i = 0; i < mSelectableButtons.Count; i++)
        {
            mSelectableButtons[i].SetSelectedWithoutNotify(i == ind);
        }
    }


    public void Clear()
    {
        foreach (var btn in mSelectableButtons)
            Destroy(btn.gameObject);

        mSelectableButtons.Clear();
    }
}
