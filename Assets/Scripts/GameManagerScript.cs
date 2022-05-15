using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
public GameObject rendaSound;
    int count;
    public Text countText;
    public Text timerText;
    float timer = 10.0f;
    bool isPlaying = false;
    public Text buttonText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isPlaying == true)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("f2");
        }
        if (timer < 0)
        {
            isPlaying = false;
            timer = 0;
            timerText.text = timer.ToString("f2");
            PlayerPrefs.SetInt("Score", count);
            SceneManager.LoadScene("EndScene");
        }
    }

    public void CountUp()
    {
        if (isPlaying == true)
        {
            count += 1;
        
            countText.text = count.ToString();
            Debug.Log(count);
            GameObject rendaSoundClone = Instantiate(rendaSound)as GameObject;    //ここを追加
            Destroy(rendaSoundClone, 3.0f);
        }
        else
        {
            isPlaying = true;
            buttonText.text = "押せ！";
            countText.text = "0";

        }

    }
}