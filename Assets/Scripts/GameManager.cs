using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int m_FoodAmount = 100;
    public static GameManager Instance { get; private set; }
    public BoardManager boardManager;
    public PlayerController playerController;
    public TurnManager TurnManager { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnManager = new TurnManager();
        TurnManager.OnTick += OnTurnHappen;
        boardManager.Init();
        playerController.Spawn(boardManager, new Vector2Int(1, 1));
    }

    private void OnTurnHappen()
    {
        m_FoodAmount -= 1;
        Debug.Log("Current amount of food : " + m_FoodAmount);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
