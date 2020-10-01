using UnityEngine;

public abstract class ItemMonoBehaviour : MonoBehaviour, IPickupable
{
    public abstract Item Item { get; }
    public abstract void Initialize();

    public void PickUp(Minion minion)
    {
        if(minion.GetComponent<Backpack>().AddItem(Item))
        {
            Destroy(gameObject);
        }
        else
        {
            //Brak miejsca w inwentory
        }

    }
}
