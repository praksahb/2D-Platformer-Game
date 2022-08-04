using UnityEngine;

public class AnimationLengths : MonoBehaviour
{

    private Animator anim;
    private AnimationClip clip;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Log("Error: Did not find anim!");
        }
        else
        {
            Debug.Log("Got anim");
        }

        UpdateAnimClipTimes();
    }
    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            //Debug.Log("Clip Name: " + clip.name);
            //Debug.Log("Clip Length: " + clip.length);
            //Debug.Log(clip.ToString());

            if(clip.name == "Player_Hurt")
            {
            Debug.Log("Clip Length: " + clip.length);
            }
        }
    }
}
