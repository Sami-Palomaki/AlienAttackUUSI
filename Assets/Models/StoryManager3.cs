using UnityEngine;
using TMPro;
using System.Collections;
using DG.Tweening;

public class StoryManager3 : MonoBehaviour
{
    
    public TextMeshProUGUI storyTextMeshPro;
    public string storyText;
    private int currentIndex = 0;
    public float letterDelay = 0.1f;

    public IEnumerator RevealText()
    {
        
        while (currentIndex < storyText.Length)
        {
            storyTextMeshPro.text = storyText.Substring(0, currentIndex + 1);
            currentIndex++;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}