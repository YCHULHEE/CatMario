using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject life;
    int lifeScore =3;
    

    public void LifeDown()
    {
        this.lifeScore--;
        PlayerPrefs.SetInt("life", lifeScore);
    }
    
    public void ChangeScene()
    {
        if (lifeScore == 0)
        {
            SceneManager.LoadScene("GameOver");
            PlayerPrefs.DeleteKey("life");
        }
        else
        {
            SceneManager.LoadScene("GameScene2");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        this.life = GameObject.Find("Text");
        if (!PlayerPrefs.HasKey("life"))
            PlayerPrefs.SetInt("life", 3);
        else
        {
            int curlife = PlayerPrefs.GetInt("life");
            lifeScore = curlife;
        }
    }

    // Update is called once per frame
    void Update()
    {

        this.life.GetComponent<Text>().text = "X " + this.lifeScore.ToString();

    }
}
