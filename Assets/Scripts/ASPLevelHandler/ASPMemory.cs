using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASPMemory : MonoBehaviour
{
    public string memory { get { return generateMemory(); } }
    protected abstract string generateMemory();

}
