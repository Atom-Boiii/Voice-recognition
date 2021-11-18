using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeechInput
{
    public AnswerType type;

    [TextArea]
    public string input;

    public GameObject activatedObject;
}

public enum AnswerType
{
    Greeting,
    Welfare,
    Activation
}
