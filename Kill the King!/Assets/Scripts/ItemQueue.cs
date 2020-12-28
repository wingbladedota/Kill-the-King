using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemQueue : MonoBehaviour
{
    public enum Actions
    {
        Jump, Attack
    }
    public List<Actions> itemQueue = new List<Actions>();

    public void AddJump()
    {
        itemQueue.Add(Actions.Jump);
    }
    public void AddAttack()
    {
        itemQueue.Add(Actions.Attack);
    }

}
