using UnityEngine;

public class Collectable : Collidable
{
    // Logic
    protected bool collected;

    protected override void OnCollide(Collider2D collider)
    {
        if(collider.name == "Player")
            OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
