using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{


    public class DialogueLine : DialogueBaseClass
    {
        
        private Text textHolder;

        [Header ("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color32 textColor;
        [SerializeField] private Font textFont;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
        }

        private void Start()
        {
            StartCoroutine(WriteText(input,textHolder, textFont, textColor, delay, sound, delayBetweenLines));
        }
    }
}