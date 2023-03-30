using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
[Serializable]public struct AnimList
{
    public string AnimationToPlay;
    public bool AnimationDonePlaying;
    public int ExecutionLevel;

    public AnimList(string _animToPlay, bool _donePlaying, int _executionLevel)
    {
        AnimationToPlay = _animToPlay;
        AnimationDonePlaying = _donePlaying;
        ExecutionLevel = _executionLevel;
    }
}

public class anim : MonoBehaviour
{
    public Animator animator;
    public List<AnimList> animList;
    public int MasterExecutionLevel;
    public int _internalExecutionLevel;
    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = false;
        
    }

    private void OnEnable()
    {
        EventManager.OnGameAction += ManageEvents;   
    }

    

    private void OnDisable()
    {
        EventManager.OnGameAction -= ManageEvents;

    }

    private void ManageEvents(int _executionLevel, object _o)
    {
        if (_executionLevel == MasterExecutionLevel)
        {
            StartCoroutine("GetAnimationAndPlayAnimator");
        }
    }

    private IEnumerator GetAnimationAndPlayAnimator()
    {
        animator.enabled = true;
        
            foreach (AnimList animListP in animList)
            {
                if (animListP.ExecutionLevel == _internalExecutionLevel)
                {
                    animator.Play(animListP.AnimationToPlay, 0, 0.0f);
                    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
                    _internalExecutionLevel++;
                    //StartCoroutine("GetAnimationAndPlayAnimator");
            }
                else if (animList.Count <= _internalExecutionLevel)
                {
                    EventManager.DoGameAction(MasterExecutionLevel++, null);
                }
            }
    }
        
        
    }

