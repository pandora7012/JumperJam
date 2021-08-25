using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchivementUI : MonoBehaviour
{
    public Text st; 
    public Text nd;
    public Text rd;


    
    void Update()
    {
        st.text = PlayerPrefs.GetInt("first").ToString();
        nd.text = PlayerPrefs.GetInt("second").ToString();
        rd.text = PlayerPrefs.GetInt("third").ToString();
    }

    public void closeButton()
    {
        gameObject.SetActive(false);
    }
}
