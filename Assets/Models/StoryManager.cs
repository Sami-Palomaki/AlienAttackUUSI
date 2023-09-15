using UnityEngine;
using TMPro;
using System.Collections;
public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI storyTextMeshPro;
    public string storyText;
    private int currentIndex = 0;
    public float letterDelay = 0.1f;  // Adjust this value to control the delay between letters

    private void Start()
    {
        StartCoroutine(RevealText());
    }

    private IEnumerator RevealText()
    {
        while (currentIndex < storyText.Length)
        {
            storyTextMeshPro.text = storyText.Substring(0, currentIndex + 1);
            currentIndex++;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}
