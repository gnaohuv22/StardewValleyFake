using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] float spread = 0.7f;

    [SerializeField] Item item;
    [SerializeField] int itemCountInOneDrop = 1;
    [SerializeField] int dropAmount = 3;
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
}
