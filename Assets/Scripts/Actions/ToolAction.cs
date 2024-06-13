using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply() not implemented");
        return true;
    }

    public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController titeMapReadController,
        Item item) {

        Debug.LogWarning("OnApplyToTileMap is not implemented");
        return true;
    
    }

    public virtual void OnItemUse(Item usedItem, ItemContainer inventory)
    {
        

    }
}
