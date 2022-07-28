using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int rabbitCount = 3;
    [SerializeField] private int wolfCount = 3;
    [SerializeField] private int deerCount = 3;

    private static GameController _gameController;
    private void Awake()
    {
        SerializeSingelton();
    }

    private void SerializeSingelton()
    {
        if (_gameController != null)
        {
            var controller = gameObject;
            controller.SetActive(false);
            Destroy(controller);
        }
        else
        {
            _gameController = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int RabbitCount
    {
        get => rabbitCount;
        set => rabbitCount = value;
    }
    public int WolfCount
    {
        get => wolfCount;
        set => wolfCount = value;
    }
    public int DeerCount
    {
        get => deerCount;
        set => deerCount = value;
    }
}
