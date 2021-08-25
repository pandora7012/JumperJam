using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public DATA data;
    private int currentPos;
    public Sprite nonSprite;
    public Image prev;
    public Image curr;
    public Image next;
    public Text cost;
    public Text coin;
    public GameObject chaStore;
    public GameObject mapStre;

    public static int mod;
    //public Text Ability;
    

    void Start()
    {
        currentPos = 0;
        mod = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mod == 0)
        {
            chaStore.SetActive(true);
            mapStre.SetActive(false);
        }
        else
        {
            chaStore.SetActive(false);
            mapStre.SetActive(true);
        }
        if (data.characters[currentPos].Trigger == false)
            cost.text = data.characters[currentPos].cost.ToString() + " $";
        else cost.text = "Owned";
        coin.text = PlayerPrefs.GetInt("coin").ToString();
        
        curr.sprite = data.characters[currentPos].idle;
        if (currentPos - 1 < 0)
        {
            prev.color = new Color(1, 1, 1, 0);
        }
        else
        {
            prev.sprite = data.characters[currentPos - 1].idle;
            prev.color = new Color(1, 1, 1, 1);
        }
        if (currentPos + 1 > data.characters.Length - 1)
        {
            next.color = new Color(1, 1, 1, 0);
        }
        else
        {
            next.sprite = data.characters[currentPos + 1].idle;
            next.color = new Color(1, 1, 1, 1);
        }
        
    }

    public void PreButton()
    {
        currentPos  = Mathf.Clamp(currentPos-1,0, data.characters.Length-1);
    }

    public void NextButton()
    {
       
       currentPos =  Mathf.Clamp(currentPos+1, 0, data.characters.Length - 1);
    }

    public void CloseButton()
    {
        this.gameObject.SetActive(false);
    }

    public void BuyButton ()
    {
        int coin = PlayerPrefs.GetInt("coin");
        if (coin >= data.characters[currentPos].cost 
            && data.characters[currentPos].Trigger == false)
        {
            coin -= data.characters[currentPos].cost;
            PlayerPrefs.SetInt("coin", coin);
            data.characters[currentPos].Trigger = true;
        }
        else if ( data.characters[currentPos].Trigger == true)
        {
            int p = data.characters[currentPos].ID;
            PlayerPrefs.SetInt("character", p);
        }
    }

    public void change()
    {
        StoreUI.mod = 1;
    }
}
