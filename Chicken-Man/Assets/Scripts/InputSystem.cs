using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InputSystem : ComponentSystem
{
    private struct Data
    {
        public readonly int  Length;
        public ComponentArray<InputComponent> InputComponents;
    }
    [Inject] private Data data;
    protected override void OnUpdate()
    {
#if UNITY_EDITOR
        for (int i = 0; i < data.Length; i++)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            data.InputComponents[i].Horizontal = horizontal;
            data.InputComponents[i].Vertical = vertical;
        }
#else
        
#endif

    }
}
