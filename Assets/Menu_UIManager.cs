using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_UIManager : MonoBehaviour
{
    public GameObject StoreUI;
    public GameObject ArchivementUI;
    public GameObject settingUI;
    public AudioSource audio;
    public static bool pk = true;
    public Image buttonChange;
    public Sprite on;
    public Sprite off;

    private void Awake()
    {
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (pk == true)
        {
            audio.volume = 1;
            buttonChange.sprite = on;
        }
        else
        {
            audio.volume = 0;
            buttonChange.sprite = off;
        }

        PlayerPrefs.SetFloat("audio", audio.volume);
    }

        public void onoffAudio ()
    {
        if (pk == true) pk = false;
        else pk = true;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1; 
    }

    public void storeButton ()
    {
        StoreUI.SetActive(true);
    }

    public void ArchivementButton ()
    {
        ArchivementUI.SetActive(true);
    }
    public void settingButton ()
    {
        settingUI.SetActive(true);
    }
    
}
