using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubGeneratorBase : MonoBehaviour
{
    public int Priority;
    public bool HasFinished;

    public virtual void GenerateNext()
    { }
}
