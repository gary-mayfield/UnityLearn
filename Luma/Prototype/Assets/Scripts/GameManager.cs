using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    public FloatingTextManager floatingTextManager;

    // References
    public Player player;

    // Logic
    public int currency;
    public int experience;

    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    public void SaveState()
    {
        string saveState = "";
        saveState += "0" + "|";
        saveState += currency.ToString() + "|";
        saveState += experience.ToString() + "|";
        saveState += "0";

        PlayerPrefs.SetString("SaveState", saveState);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // TODO: Change player skin
        currency = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // TODO: Change weapon level
    }
}
