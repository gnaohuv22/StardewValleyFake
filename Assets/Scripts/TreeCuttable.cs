using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropAmount = 3;
    [SerializeField] float spread = 0.7f;
    public override void Hit()
    {
        while (dropAmount > 0)
        {
            --dropAmount;
            Vector3 position = transform.position;
            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;
        }
        Destroy(gameObject);
    }
}
