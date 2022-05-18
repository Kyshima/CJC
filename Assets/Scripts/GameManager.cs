using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Reference to Scripts
    public Player player;

    public int floor;

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
    public Animator deathAnim;
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

    public int getLevel()
    {
        int r = 0;
        int add = 0;

        while(xp >= add)
        {
            add += xpTable[r];
            r++;

            if (r == xpTable.Count) return r;
        }
        return r;   
    }

    public int getXPLevel(int level)
    {
        int r = 0;
        int exp = 0;

        while (r < level)
        {
            exp += xpTable[r];
            r++;
        }
        return exp;
    }

    public void Respawn()
    {
        deathAnim.SetTrigger("Hide");
        SceneManager.LoadScene("Start_D");
        player.Respawn();
    }

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += player.hp.ToString() + "|";
        s += money.ToString() + "|";
        s += xp.ToString() + "|";
        s += weapon.weaponLevel.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
        //Debug.Log("SaveState");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {   
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        player.hp = int.Parse(data[1]);
        money = int.Parse(data[2]);
        xp = int.Parse(data[3]);
        weapon.weaponLevel = int.Parse(data[4]);

        GameObject.Find("Player").transform.position = GameObject.Find("Spawn").transform.position;
    }
}
