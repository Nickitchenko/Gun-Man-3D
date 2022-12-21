using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text moneyText;
    
    void Update()
    {
        //transform.GetComponent<TextMesh>().text= "$" + PlayerStats.Money.ToString();
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
