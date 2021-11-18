using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answer
{
    public AnswerType type;

    [TextArea]
    public string response;
}

