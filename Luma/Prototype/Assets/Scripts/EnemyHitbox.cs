using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int damagePoint;
    public float pushForce;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Fighter" && collider.name == "Player")
        {
            Damage damage = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            collider.SendMessage("ReceiveDamage", damage);
        }
    }
}
