using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFieldInputManager : MonoBehaviour
{
    public InputField speedInput;
    public InputField timeSpawnInput;
    public InputField distanceCubeInput;

    private CubeSpawner cubeSpawner;

    private void Start()
    {
        cubeSpawner = GameObject.Find("CubeSpawner").GetComponent<CubeSpawner>();
        ChangeInTextSpeed();
        ChangeInTextDistance();
        ChangeInTextTime();
    }

    public void ChangeInTextSpeed()
    {
        if (float.TryParse(speedInput.text, out float num))
        {
            if (num == 0)
            {
                cubeSpawner.SetSpeedFromInput(2);
            }
            else
            {
                cubeSpawner.SetSpeedFromInput(num);
            }
        }
        else
        {
            cubeSpawner.SetSpeedFromInput(2);
        }
    }

    public void ChangeInTextDistance()
    {
        if (float.TryParse(distanceCubeInput.text, out float num))
        {
            if (num == 0)
            {
                cubeSpawner.SetDistanceFromInput(2);
            }
            else
            {
                cubeSpawner.SetDistanceFromInput(num);
            }
        }
        else
        {
            cubeSpawner.SetDistanceFromInput(2);
        }
    }

    public void ChangeInTextTime()
    {
        if (float.TryParse(timeSpawnInput.text, out float num))
        {
            if (num == 0)
            {
                cubeSpawner.SetTimeFromInput(2);
            }
            else
            {
                cubeSpawner.SetTimeFromInput(num);
            }
        }
        else
        {
            cubeSpawner.SetTimeFromInput(2);
        }
    }
}
