using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public int width;
    public int height;

    public Vector2Int mousePos;

    public Color light_tile;
    public Color dark_tile;

    private Color tile_color;

    public GameObject tile_p;

    private Camera cam;

    void Setup()
    {
        bool is_light = true;
        // spawn a grid of "tile_p" prefabs
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                GameObject newTile = Instantiate(tile_p, new Vector3(i - (width/2f) + 0.5f, j - (height / 2f) + 0.5f, 0), Quaternion.identity);
                newTile.transform.parent = this.transform;
                if (is_light)
                {
                    tile_color = light_tile;
                }
                else
                {
                    tile_color = dark_tile;
                }

                newTile.GetComponent<SpriteRenderer>().color = tile_color;
                is_light = !is_light;

                Tile tile = newTile.GetComponent<Tile>();
                tile.coord = new Vector2Int(i, j);
                tile.id = BoardTools.CoordToName(tile.coord);

                newTile.name = tile.id;
            }
            is_light = !is_light;
        }
        
    }


    public Vector2Int MouseToCoord(Vector2 mousePos)
    {

        Vector2 offsetMousePos = (mousePos + new Vector2(width/2f - 0.5f , height / 2f - 0.5f));
        int coordCellX = Mathf.RoundToInt(offsetMousePos.x);
        int coordCellY = Mathf.RoundToInt(offsetMousePos.y);
        return new Vector2Int(coordCellX, coordCellY);
    }


    private void Start()
    {
        cam = Camera.main;
        Setup();
    }


    private void Update()
    {
        mousePos = MouseToCoord(cam.ScreenToWorldPoint(Input.mousePosition));
    }






}
