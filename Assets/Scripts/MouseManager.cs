using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GridManager Grid;
    public bool enableDebug = false;

    void Update()
    {
        if(enableDebug)
        {
        Debug.Log(Grid.GetTileAtMousePos(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }
}
