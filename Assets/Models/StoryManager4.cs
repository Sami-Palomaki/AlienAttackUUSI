using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class StoryManager4 : MonoBehaviour
{
    public string sceneToLoad;
    public TextMeshProUGUI storyTextMeshPro;
    public string storyText;
    private int currentIndex = 0;
    public float letterDelay = 0.1f;
    public StorySequenceManager sequenceManager;

public IEnumerator RevealText()
{
    while (currentIndex < storyText.Length)
    {
        storyTextMeshPro.text = storyText.Substring(0, currentIndex + 1);
        currentIndex++;
        yield return new WaitForSeconds(letterDelay);
    }

    // Wait for spacebar press
    while (!Input.GetKeyDown(KeyCode.Space))
    {
        yield return null;
    }

    // Transition to the specified scene smoothly using DOTween
    DOTween.Clear(); // Clear any existing tweens
    float fadeDuration = 1.0f; // Adjust this duration as needed
    DOTween.ToAlpha(() => storyTextMeshPro.color, color => storyTextMeshPro.color = color, 0f, fadeDuration)
        .OnComplete(() => SceneManager.LoadScene(sceneToLoad));
}


}
