using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ResourceNode : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] float spread = 0.7f;

    [SerializeField] Item item;
    [SerializeField] int itemCountInOneDrop = 1;
    [SerializeField] int dropAmount = 3;
    [SerializeField] ResourceNodeType nodeType;
    public override void Hit()
    {
        while (dropAmount > 0)
        {
            --dropAmount;
            Vector3 position = transform.position;
            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;

            ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);
        }
        Destroy(gameObject);
    }

    public override bool CanBeHit(List<ResourceNodeType> canBeHit)
    {
        return canBeHit.Contains(nodeType);
    }
}
