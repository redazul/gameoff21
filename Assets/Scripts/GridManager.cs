using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{

    private Grid _grid;
    private Tilemap _tileMap;

    private void Awake()
    {
        _grid = gameObject.GetComponent<Grid>();
        _tileMap = gameObject.GetComponentInChildren<Tilemap>();
    }

    public Tile GetTileAtMousePos(Vector3 mousePos)
    {
        Vector3Int mouseGridPos = _grid.WorldToCell(new Vector3(mousePos.x, mousePos.y, 0));
        Debug.Log(mouseGridPos);
        return _tileMap.GetTile<Tile>(mouseGridPos);
    }
}
