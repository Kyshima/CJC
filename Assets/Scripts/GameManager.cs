using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Reference to Scripts
    public Player player;

    public void Awake()
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

    //Resources
    public List<Sprite> weaponSprite;
    public List<int> xpTable;

    
    public Weapon weapon;

    public FloatingTextManager floatingTextManager;

    //Code

    public int money;
    public int xp;


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }

    public void Upgrade()
    {
        weapon.UpgradeWeapon();
    }
    public void Downgrade()
    {
        weapon.DowngradeWeapon();
    }

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += money.ToString() + "|";
        s += xp.ToString() + "|";
        s += weapon.weaponLevel.ToString();
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("SaveState");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {   
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        money = int.Parse(data[1]);
        xp = int.Parse(data[2]);
        weapon.weaponLevel = int.Parse(data[3]);

        GameObject.Find("Player").transform.position = GameObject.Find("Spawn").transform.position;

    }
}
