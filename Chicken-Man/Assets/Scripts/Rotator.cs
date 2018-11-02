using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float Speed;
   
}
class RotatorSystem:ComponentSystem
{
    struct Components
    {
        public Rotator rotator;
        public Transform transform;
    }
    protected override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;
        foreach (var item in GetEntities<Components>())
        {
            item.transform.Rotate(0f, item.rotator.Speed * deltaTime, 0f);
        } 
    }
}