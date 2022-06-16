using UnityEngine;

public class SaleArea : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Backpack backpack))
        {
            if (!backpack.IsEmpty)
            {
                backpack.SellHeysCount();
                //backpack.GetComponent<Wallet>().AddCoins();
            }
        }
    }
}
