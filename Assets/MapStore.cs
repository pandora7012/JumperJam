using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseButton0()
    {
        PlayerPrefs.SetInt("MAP", 0);
    }
    public void chooseButton1()
    {
        PlayerPrefs.SetInt("MAP", 1);
    }
    public void chooseButton2()
    {
        PlayerPrefs.SetInt("MAP", 2);
    }
    public void chooseButton3()
    {
        PlayerPrefs.SetInt("MAP", 3);
    }
    public void chooseButton4()
    {
        PlayerPrefs.SetInt("MAP", 4);
    }

    public void change()
    {
        StoreUI.mod = 0; 
    }
    
}
