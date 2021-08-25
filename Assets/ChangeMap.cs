using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    public SpriteRenderer layer1_1;
    public SpriteRenderer layer1_2;
    public SpriteRenderer layer1_3;

    public SpriteRenderer layer2_1;
    public SpriteRenderer layer2_2;
    public SpriteRenderer layer2_3;

    public SpriteRenderer layer3_1;
    public SpriteRenderer layer3_2;
    public SpriteRenderer layer3_3;

    public Sprite l1;
    public Sprite l2;
    public Sprite l3;

    public DATA data;
    void Start()
    {
        
        int p = PlayerPrefs.GetInt("MAP");
        Debug.Log(p);
        l1 = data.maps[p].layer1;
        l2 = data.maps[p].layer2;
        l3 = data.maps[p].layer3;

        layer1_1.sprite = layer1_2.sprite = layer1_3.sprite = l1;
        layer2_1.sprite = layer2_2.sprite = layer2_3.sprite = l2;
        layer3_1.sprite = layer3_2.sprite = layer3_3.sprite = l3;
    }
}
