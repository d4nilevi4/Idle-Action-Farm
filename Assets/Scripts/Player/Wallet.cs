using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinsCount;
    [SerializeField] private CoinsBoard _coinsBoard;
    public int CoinsCount => _coinsCount;

    public void AddCoins(int coins)
    {
        _coinsCount += coins;
        _coinsBoard.UpdateCoinsBoard(_coinsCount);
    }
}
