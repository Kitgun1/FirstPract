using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;

    public void SetCoin(int value)
    {
        _coinsText.text = value.ToString();
    }
}
