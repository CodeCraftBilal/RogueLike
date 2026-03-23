using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public class CellData
    {
        public bool passable;
        public GameObject ContainedObject;
    }

    private CellData[,] m_BoardData;
    private Tilemap m_timeMap;
    public int width;
    public int height;
    public Tile[] GroundTiles;
    public Tile[] WallTiles;
    private Grid m_Grid;
    public PlayerController Player;
    public GameObject FoodPrefab;
    private List<Vector2Int> m_EmptyCellsList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Init()
    {
        m_Grid = GetComponentInChildren<Grid>();
        m_timeMap = GetComponentInChildren<Tilemap>();
        m_EmptyCellsList = new List<Vector2Int>();

        m_BoardData = new CellData[width, height];
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                Tile tile;
                m_BoardData[x, y] = new CellData();
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                    m_BoardData[x, y].passable = false;
                }
                else
                {
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                    m_BoardData[x, y].passable = true;
                    m_EmptyCellsList.Add(new Vector2Int(x, y));
                }
                m_timeMap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
        m_EmptyCellsList.Remove(new Vector2Int(1, 1));
        GenerateFood();
    }

    public Vector3 CellToWorld(Vector2Int cellIndex)
    {
        return m_Grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }

    public CellData GetCellData(Vector2Int cellIndex)
    {
        if (cellIndex.x < 0 || cellIndex.x >= width
            || cellIndex.y < 0 || cellIndex.y >= height)
        {
            return null;
        }

        return m_BoardData[cellIndex.x, cellIndex.y];
    }

    void GenerateFood()
    {
        int foodCount = 5;
        for (int i = 0; i < foodCount; ++i)
        {
            int randomIndex = Random.Range(0, m_EmptyCellsList.Count);
            Vector2Int coord = m_EmptyCellsList[randomIndex];
            m_EmptyCellsList.RemoveAt(randomIndex);

            CellData data = m_BoardData[coord.x, coord.y];
            GameObject newFood = Instantiate(FoodPrefab);
            newFood.transform.position = CellToWorld(coord);
            data.ContainedObject = newFood;
        }
    }
}
