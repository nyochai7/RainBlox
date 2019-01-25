using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Main Menu")]
    [SerializeField]
    private MainMenu _mainMenuPrefab;
    [SerializeField]
    private Button.ButtonClickedEvent _mainMenuPlayClickEvent;

    private MainMenu _mainMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        _mainMenu = Instantiate(_mainMenuPrefab, Vector3.zero, Quaternion.identity);
        _mainMenu.playButton.onClick = _mainMenuPlayClickEvent;

        OpenMainMenu();
        DontDestroyOnLoad(gameObject);
    }

    public void StartGamePlay()
    {
        Time.timeScale = 1f;
        _mainMenu.gameObject.SetActive(false);
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 0;
        _mainMenu.gameObject.SetActive(true);
    }

}
