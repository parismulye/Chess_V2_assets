using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] Board board;
    [SerializeField] PieceManager pm;

    private Camera cam;
    private Vector2 mousePos;
    private Tile startingTile;
    private Tile targetTile;

    // actievePiec could be made private at a later time
    public Piece activePiece = null;
    

    public Vector2Int mouseCoord;

    private void Awake()
    {
        cam = Camera.main;
    }


    private void Update()
    {
        // at every frame, get current mouse position in cell coordinates
        UpdateMouseCoord();



        // when I click down on mouse:
        if (Input.GetMouseButtonDown(0))
        {
            startingTile = GetTile(mouseCoord);
            
            // if there is a piece:
            if (startingTile.currentPiece != null)
            {
                activePiece = startingTile.currentPiece;
                activePiece.Activate();

                // highlight legal tiles on the board...

            }
        }

        // while mouse button is held down:
        if (Input.GetMouseButton(0))
        {
            DragPiece(activePiece);
        }


        // when I release the mouse:
        if (Input.GetMouseButtonUp(0))
        {
            targetTile = GetTile(mouseCoord);
            if (activePiece)
            {
                pm.ComputeAction(activePiece, targetTile);
                activePiece.Deactivate();
                activePiece = null;
            }
            
        }



    }



    Tile GetTile(Vector2Int mouseCoord)
    {
        Tile selectedTile = board.tiles[mouseCoord.x, mouseCoord.y];
        return selectedTile;
    }

    void DragPiece(Piece activePiece)
    {
        if (activePiece != null)
        {
            activePiece.transform.position = mousePos;
        }
    }



    private Vector2Int UpdateMouseCoord()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseCoord = MouseToCoord(mousePos);
        return mouseCoord;
    }


    private Vector2Int MouseToCoord(Vector2 mousePos)
    {
        Vector2 offsetMousePos = (mousePos + new Vector2(board.width/2 - 0.5f , board.height / 2 - 0.5f));
        int coordCellX = Mathf.RoundToInt(offsetMousePos.x);
        int coordCellY = Mathf.RoundToInt(offsetMousePos.y);
        return new Vector2Int(coordCellX, coordCellY);
    }
}
