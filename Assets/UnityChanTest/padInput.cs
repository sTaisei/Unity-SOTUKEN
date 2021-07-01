using UniSense;
using UnityEngine;


public abstract class padInput : MonoBehaviour
{

    public DualSenseGamepadHID DualSense { get; protected set; }

    internal virtual void OnConnect(DualSenseGamepadHID dualSense)
           => DualSense = dualSense;

    internal virtual void OnDisconnect() => DualSense = null;
}
