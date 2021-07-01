using UniSense;
using UnityEngine;

public class pad : padInput
{
    [SerializeField]
    private byte a;
    [SerializeField]
    private byte b;
    [SerializeField]
    private byte c;
    private DualSenseTriggerState rightTriggerState;
    private DualSenseTriggerState leftTriggerState;

    private void Start()
    {
        rightTriggerState.Section.StartPosition = 255;
        rightTriggerState.Section.Force = 255;
        rightTriggerState.Section.EndPosition = 255;
    }

    private void Update()
    {
        var state = new DualSenseGamepadState
        {
            LeftTrigger = leftTriggerState,
            RightTrigger = rightTriggerState
        };
        DualSense?.SetGamepadState(state);
    }

    private void Awake()
    {
        leftTriggerState = new DualSenseTriggerState
        {
            EffectType = DualSenseTriggerEffectType.ContinuousResistance,
            EffectEx = new DualSenseEffectExProperties(),
            Section = new DualSenseSectionResistanceProperties(),
            Continuous = new DualSenseContinuousResistanceProperties()
        };

        rightTriggerState = new DualSenseTriggerState
        {
            EffectType = DualSenseTriggerEffectType.ContinuousResistance,
            EffectEx = new DualSenseEffectExProperties(),
            Section = new DualSenseSectionResistanceProperties(),
            Continuous = new DualSenseContinuousResistanceProperties()
        };
    }

    public void SetRight(byte a)
    {
        Debug.Log("setRight" + a);
        rightTriggerState.Section.StartPosition = a;
    }


}
