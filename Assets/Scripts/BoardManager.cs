using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    private Tilemap m_timeMap;
    public int width;
    public int height;
    public Tile[] GroundTiles;
    public Tile[] WallTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_timeMap = GetComponentInChildren<Tilemap>();    
        for(int y = 0; y < height; ++y)
        {
            Debug.Log("y: " + y);
            for(int x = 0; x < width; ++x)
            {
                Tile tile;
                if(x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                    
                } else
                {
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                }
                m_timeMap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
