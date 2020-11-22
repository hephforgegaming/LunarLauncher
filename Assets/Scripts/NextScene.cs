using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneToLoad;
    public float timeToWait;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadNext());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator loadNext()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadSceneAsync(sceneToLoad);
        yield return null;
    }
}
