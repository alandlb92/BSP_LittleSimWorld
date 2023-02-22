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

    public void SelectedByIndex(int ind)
    {
        mSelectableButtons[ind].Select();
    }
}
