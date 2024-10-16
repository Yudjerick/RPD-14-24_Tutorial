using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int coinCount = 0;
    public TMP_Text counter;

    public void AddCoin()
    {
        coinCount++;
        counter.text = coinCount.ToString();
    }
}
