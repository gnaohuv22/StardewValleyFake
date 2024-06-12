using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/ToolAction/Plow Tile")]
public class PlowTile : ToolAction
{
    [SerializeField] List<TileBase> canPlow;
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController titeMapReadController)
    {
        TileBase tileToPlow = titeMapReadController.GetTileBase(gridPosition);

        if (canPlow.Contains(tileToPlow) == false)
        {
            return false;
        }
        titeMapReadController.cropsManager.Plow(gridPosition);

        return true;
    }
}
