using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 12;
    int selectedTool;

    internal void Set(int id)
    {
        selectedTool = id;
    }

    public Action<int> OnChange;

    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                selectedTool = (selectedTool + 1) % toolbarSize;
            }
            else
            {
                selectedTool = (selectedTool - 1 + toolbarSize) % toolbarSize;
            }
            OnChange?.Invoke(selectedTool);
        }
    }
}
