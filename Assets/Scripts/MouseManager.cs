using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GridManager Grid;

    void Update()
    {
        Debug.Log(Grid.GetTileAtMousePos(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
    }
}
