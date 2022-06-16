using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;

    public void UpdateCoinsBoard(int coinsCount)
    {
        _coinsText.text = coinsCount.ToString();
    }
}
