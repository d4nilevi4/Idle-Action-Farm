using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CoinEffect : MonoBehaviour
{
    private Transform _coinUIPosition;

    public void CoinMoveEffect(Transform coinUITransform)
    {
        _coinUIPosition = coinUITransform;
        transform.DOMove(coinUITransform.position, 0.1f);
        Destroy(gameObject, 0.1f);
    }
}
