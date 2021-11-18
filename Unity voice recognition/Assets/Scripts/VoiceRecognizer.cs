using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class VoiceRecognizer : MonoBehaviour
{
    public SpeechInput[] inputs;

    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    public TMP_InputField inputText, responseText;

    private List<string> keyWords = new List<string>();
    private KeywordRecognizer recognizer;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in inputs)
        {
            keyWords.Add(item.input.ToLower());
        }

        string[] words = keyWords.ToArray();

        recognizer = new KeywordRecognizer(words, confidence);
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        recognizer.Start();
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        inputText.text = args.text;

        foreach (var item in inputs)
        {
            if(args.text == item.input.ToLower())
            {
                if(item.type == AnswerType.Activation)
                {
                    if(item.input == "red light on")
                    {
                        item.activatedObject.SetActive(true);
                    }else if(item.input == "red light off")
                    {
                        item.activatedObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
