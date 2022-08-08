using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayableDirector))]
public class SceneLoader : MonoBehaviour
{
    PlayableDirector playableDirector;

    [SerializeField]
    PlayableAsset fadeOutTimeline;

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void Load(string name)
    {
        StartCoroutine(LoadCoroutine(name));
    }

    IEnumerator LoadCoroutine(string name)
    {
        yield return FadeSceneOutCoroutine();

        SceneManager.LoadScene(name);
    }

    IEnumerator FadeSceneOutCoroutine()
    {
        playableDirector.Play(fadeOutTimeline);

        yield return new WaitForSeconds((float)playableDirector.duration);
    }
}
