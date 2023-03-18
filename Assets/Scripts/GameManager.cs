using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public Button playButton;
    public TextMeshProUGUI text;
    public GameObject player;
    public TMP_Dropdown dropDown;

    private const string SAVE_KEY = "SAVE";


    private void OnEnable()
    {
        text.text = "Start Game Ples";
        playButton.onClick.AddListener(StartGame);
        dropDown.onValueChanged.AddListener(OnDropSelectionMade);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(StartGame);
    }

    public void StartGame()
    {
        playButton.gameObject.SetActive(false);
        player.SetActive(true);
        PlayerPrefs.SetString(SAVE_KEY, "HasSaved");
        PlayerPrefs.Save();

        if(PlayerPrefs.HasKey(SAVE_KEY))
        {
            var saveString = PlayerPrefs.GetString(SAVE_KEY);
        }
    }

    private void OnDropSelectionMade(int choice)
    {

    }
}
