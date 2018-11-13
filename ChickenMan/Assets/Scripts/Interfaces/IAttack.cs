using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
     void Attack(int attackDamage,ITakeDamage objectToAttack);

}
