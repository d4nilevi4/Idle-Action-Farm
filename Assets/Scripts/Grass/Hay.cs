using UnityEngine;

public class Hay : MonoBehaviour
{
    public static int cost = 15;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Backpack backpack))
        {
            if (!backpack.IsFull)
            {
                backpack.AddHeysCount();
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
