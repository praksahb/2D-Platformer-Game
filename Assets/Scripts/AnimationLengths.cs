using UnityEngine;

public class GetAnimationClipLengths : MonoBehaviour
{

    private Animator anim;

    // Use this for checking lengths of animation clips playing

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

    private void Update()
    {
       AnimatorClipInfo[] clips = anim.GetCurrentAnimatorClipInfo(0);
        Debug.Log("Name: " + clips[0].clip.name);
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
