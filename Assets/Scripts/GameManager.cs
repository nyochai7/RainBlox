using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Main Menu")]
    [SerializeField]
    private MainMenu _mainMenuPrefab;
    [SerializeField]
    private EndScreen _endScreenPrefab;
    [SerializeField]
    private Button.ButtonClickedEvent _mainMenuPlayClickEvent;
    [SerializeField]
    private int _goodTimeSeconds;
    [SerializeField]
    private int _fineTimeSeconds;

    private MainMenu _mainMenu;
    private EndScreen _endScreen;

    private float _startTime;

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

        _endScreen = Instantiate(_endScreenPrefab, Vector3.zero, Quaternion.identity);
        _endScreen.gameObject.SetActive(false);

        OpenMainMenu();
    }

    public void StartGamePlay()
    {
        SoundManager.Instance.Play("click");
        Time.timeScale = 1f;
        _mainMenu.gameObject.SetActive(false);
        _endScreen.gameObject.SetActive(false);
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 0;
        _mainMenu.gameObject.SetActive(true);
        _endScreen.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        Time.timeScale = 1;

        float totalTime = Time.time - _startTime;

        EndState endState = EndState.NONE;
        if (totalTime >= _goodTimeSeconds)
        {
            endState = EndState.GOOD;
        }
        else if (totalTime >= _fineTimeSeconds)
        {
            endState = EndState.FINE;
        }
        else
        {
            endState = EndState.BAD;
        }

        _endScreen.UpdateContent(endState, totalTime);
        _endScreen.gameObject.SetActive(true);

        StartCoroutine(ReloadSceneAfterDelay(4f));
    }
    
    private IEnumerator ReloadSceneAfterDelay(float delaySeconds)
    {
        yield return new WaitForSecondsRealtime(delaySeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    
}
