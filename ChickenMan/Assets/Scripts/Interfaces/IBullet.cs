using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
   
    void GiveDamage(ITakeDamage objectToHit);
}
