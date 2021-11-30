using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    private bool mFaded = false;
    public float Duration = 2f;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && !mFaded)
        {
            Fade();

            mFaded = true;
        }        
    }

    public void Fade() {
      var canvaGroup = GetComponent<CanvasGroup>();

      StartCoroutine(DoFade(canvaGroup, canvaGroup.alpha, mFaded ? 1 : 0 ));

      mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvaGroup, float start, float end) {
        float counter = 0f;

        while (counter < Duration) {
            counter += Time.deltaTime;
            canvaGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
    }
}
