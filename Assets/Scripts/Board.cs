using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] GameManager gm;

    [Header("Board parameters")]
    public int width;
    public int height;

    [SerializeField]
    private Color lightTile, darkTile;

    [Header("Tile prefab")]
    [SerializeField]
    private GameObject tile_p;

    // this 2D array will store all Tiles
    public Tile[,] tiles;
    

    public void Setup()
    {
        // initialize tiles 2D array
        tiles = new Tile[width, height];

        // store a couple of vars for coloring tiles
        bool is_light = true;
        Color tile_color;

        // spawn a grid of "tile_p" prefabs
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                // create prefab
                GameObject newTile = Instantiate(tile_p, new Vector3(i - (width/2f) + 0.5f, j - (height / 2f) + 0.5f, 0), Quaternion.identity);
                newTile.transform.parent = this.transform;

                // assign tile color
                if (is_light) { tile_color = lightTile; }
                else { tile_color = darkTile; }
                newTile.GetComponent<SpriteRenderer>().color = tile_color;

                // store tile info in Tile object
                Tile tile = newTile.GetComponent<Tile>();
                tile.coord = new Vector2Int(i, j);
                tile.id = BoardTools.CoordToName(tile.coord);
                newTile.name = tile.id;

                // finally, store the Tile in the 2D array of board
                tiles[i, j] = tile;

                // next 2 lines provide right alternance of color
                is_light = !is_light; 
            }
            if (width % 2 == 0) { is_light = !is_light; }
            
        }  
    }




}
