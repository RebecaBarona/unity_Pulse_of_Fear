using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button quitButton;


    public FadeScreen fadeScreen;
    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        //EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);

        //foreach (var item in returnButtons)
        //{
        //    item.onClick.AddListener(EnableMainMenu);
        //}

       
    }
    private void Update()
    {
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        // HideAll();
        //fadeScreen.FadeIn();
        SceneTransitionManager.singleton.GoToScene(1);
    }

    public void HideAll()
    {
       // mainMenu.SetActive(false);
    }

    public void EnableMainMenu()
    {
       // mainMenu.SetActive(true);
    }
}
