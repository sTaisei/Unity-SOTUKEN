using UniSense;
using UnityEngine;
using UnityEngine.InputSystem;


[DisallowMultipleComponent]
public sealed class padMoniter : MonoBehaviour
{
    private padInput[] listeners;

    private void Start()
    {
        listeners = GetComponentsInChildren<padInput>();
        var dualSense = DualSenseGamepadHID.FindCurrent();
        var isDualSenseConected = dualSense != null;
        if (isDualSenseConected) NotifyConnection(dualSense);
        else NotifyDisconnection();
    }

    private void OnEnable() => InputSystem.onDeviceChange += OnDeviceChange;

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
        var dualSense = DualSenseGamepadHID.FindCurrent();
        dualSense?.Reset();
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        var isNotDualSense = !(device is DualSenseGamepadHID);
        if (isNotDualSense) return;

        switch (change)
        {
            case InputDeviceChange.Added:
                NotifyConnection(device as DualSenseGamepadHID);
                break;
            case InputDeviceChange.Reconnected:
                NotifyConnection(device as DualSenseGamepadHID);
                break;
            case InputDeviceChange.Disconnected:
                NotifyDisconnection();
                break;
        }
    }

    private void NotifyConnection(DualSenseGamepadHID dualSense)
    {
        foreach (var listener in listeners)
        {
            listener.OnConnect(dualSense);
        }
    }

    private void NotifyDisconnection()
    {
        foreach (var listener in listeners)
        {
            listener.OnDisconnect();
        }
    }
}
