using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ToolAction/Seed Tile")]
public class SeedTile : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController titeMapReadController)
    {
        if (titeMapReadController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }
        titeMapReadController.cropsManager.Seed(gridPosition);
        return true;
    }

    public override void OnItemUse(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
    }
}
