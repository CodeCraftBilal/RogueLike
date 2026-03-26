using UnityEngine;
using UnityEngine.Tilemaps;

public class WallObject : CellObject
{
    public Tile obstacleTile;

    public override void Init(Vector2Int cell)
    {
        base.Init(cell);
        GameManager.Instance.boardManager.SetCellTile(cell, obstacleTile);
    }

    public override bool PlayerWantsToEnter()
    {
        // base.PlayerEntered();
        return false;
    }
}
