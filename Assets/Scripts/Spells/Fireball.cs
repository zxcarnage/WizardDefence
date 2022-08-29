using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    public override void Cast(Transform castPoint)
    {
        Projectile = GetComponent<Projectile>();
        Instantiate(Projectile,castPoint.position,Quaternion.identity);
    }

}
