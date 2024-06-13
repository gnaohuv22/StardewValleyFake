using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rigidbody2d;
    ToolbarController toolbarController;
    Animator animator;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;



    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolbarController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButton(0))
        {
            if (UseToolWorld())
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;

        markerManager.Show(selectable);
    }

    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    private bool UseToolWorld()
    {
        Vector2 position = rigidbody2d.position + character.lastMotionVector * offsetDistance;

        Item item = toolbarController.getItem;
        if (item == null) { return false; }
        if (item.onAction == null) { return false; }

        animator.SetTrigger("act");
        bool complete = item.onAction.OnApply(position);

        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUse(item, GameManager.instance.inventoryContainer);

            }
        }
        return complete;
    }

    private void UseToolGrid()
    {
        if (selectable)
        {
            Item item = toolbarController.getItem;
            if(item == null) { return; }
            if(item.onTiteMapAction == null) { return; }
            animator.SetTrigger("act");
            bool complete = item.onTiteMapAction.OnApplyToTileMap(
                selectedTilePosition,
                tileMapReadController,
                item);

            if(complete == true)
            {
                if(item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUse(item, GameManager.instance.inventoryContainer);

                }
            }
        }
    }
}
