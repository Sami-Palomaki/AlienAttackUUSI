using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StorySequenceManager : MonoBehaviour
{
    public StoryManager1 storyManager1;
    public StoryManager2 storyManager2;
    public StoryManager3 storyManager3;
    public StoryManager4 storyManager4;

    private void Start()
    {
        StartCoroutine(RunStorySequence());
    }

    private IEnumerator RunStorySequence()
    {
        
        yield return StartCoroutine(storyManager1.RevealText());
        

        
        yield return StartCoroutine(storyManager2.RevealText());
        

        
        yield return StartCoroutine(storyManager3.RevealText());
        
        
         yield return StartCoroutine(storyManager4.RevealText());
        
        
        //yield return StartCoroutine(storyManager1.RevealText());
        //yield return StartCoroutine(storyManager2.RevealText());
        //yield return StartCoroutine(storyManager3.RevealText());
    }
    
}
