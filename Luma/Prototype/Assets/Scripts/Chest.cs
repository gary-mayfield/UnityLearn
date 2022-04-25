using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int amount = 5;

    protected override void OnCollect()
    {
        if(!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.currency += amount;
            GameManager.instance.ShowText("+" + amount, 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}
