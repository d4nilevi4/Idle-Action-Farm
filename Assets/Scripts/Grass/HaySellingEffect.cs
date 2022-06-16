using UnityEngine;
using DG.Tweening;

public class HaySellingEffect : MonoBehaviour
{
    private Vector3 _salePoint;

    private void Update()
    {
        if (transform.position == _salePoint)
            Destroy(gameObject);
    }

    public void SellingEffect(Transform salePoint)
    {
        _salePoint = salePoint.position;
        transform.DOMove(salePoint.position, 1f);
    }   
}
