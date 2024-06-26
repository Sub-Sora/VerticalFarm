﻿using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HideCursor();
        UIManager.Instance.ShowCursorEvent += ShowCursor;
        UIManager.Instance.HideCursorEvent += HideCursor;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }
}
