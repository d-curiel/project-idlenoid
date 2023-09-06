using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderComponent : MonoBehaviour
{
    [SerializeField]
    Animator crossfadeAnimator;
    [SerializeField]
    int sceneToLoad;
    private string inTrigger = "In";
    private string outTrigger = "Out";
    void Start()
    {
        crossfadeAnimator.SetTrigger(inTrigger);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(PlayAnimationAndLoad(outTrigger));
    }

    public IEnumerator PlayAnimationAndLoad(string animation)
    {
        crossfadeAnimator.SetTrigger(animation);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
