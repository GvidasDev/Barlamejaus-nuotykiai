using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }
        protected IEnumerator WriteText(string input, Text textHolder, Font textFont, Color32 textColor, float delay, AudioClip sound, float delayBetweenLines)
        {
            textHolder.font = textFont;
            textHolder.color = textColor;
            for(int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];

                SoundManager.instance.PlaySound(sound);

                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(delayBetweenLines);
            finished = true;
        }
    }
}