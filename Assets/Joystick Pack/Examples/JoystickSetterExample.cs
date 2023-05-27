using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickSetterExample : MonoBehaviour
{
    public VariableJoystick leftJoystick;
    public VariableJoystick rightJoystick;
    public Text valueText;
    public Image background;
    public Sprite[] axisSprites;

    public void ModeChanged(int index)
    {
        switch(index)
        {
            case 0:
                leftJoystick.SetMode(JoystickType.Fixed);
                rightJoystick.SetMode(JoystickType.Fixed);
                break;
            case 1:
                leftJoystick.SetMode(JoystickType.Floating);
                rightJoystick.SetMode(JoystickType.Floating);
                break;
            case 2:
                leftJoystick.SetMode(JoystickType.Dynamic);
                rightJoystick.SetMode(JoystickType.Dynamic);
                break;
            default:
                break;
        }     
    }

    public void AxisChanged(int index)
    {
        switch (index)
        {
            case 0:
                leftJoystick.AxisOptions = AxisOptions.Both;
                rightJoystick.AxisOptions = AxisOptions.Both;
                background.sprite = axisSprites[index];
                break;
            case 1:
                leftJoystick.AxisOptions = AxisOptions.Horizontal;
                rightJoystick.AxisOptions = AxisOptions.Horizontal;
                background.sprite = axisSprites[index];
                break;
            case 2:
                leftJoystick.AxisOptions = AxisOptions.Vertical;
                rightJoystick.AxisOptions = AxisOptions.Vertical;
                background.sprite = axisSprites[index];
                break;
            default:
                break;
        }
    }

    public void SnapX(bool value)
    {
        leftJoystick.SnapX = value;
        rightJoystick.SnapX = value;
    }

    public void SnapY(bool value)
    {
        leftJoystick.SnapY = value;
        rightJoystick.SnapY = value;
    }

    private void Update()
    {
        valueText.text = "Current Value: " + leftJoystick.Direction;
    }
}