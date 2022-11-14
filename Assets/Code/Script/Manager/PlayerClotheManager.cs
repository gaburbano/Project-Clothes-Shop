using System.Collections.Generic;
using UnityEngine;

public class PlayerClotheManager : MonoBehaviour
{
    [SerializeField] private SO_CharacterBody characterBody;
    
    [SerializeField] private string[] bodyPartTypes;
    [SerializeField] private string[] characterStates;
    [SerializeField] private string[] characterDirections;
    
    private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides defaultAnimationClips;

    private void Start()
    {
        // Set animator
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        // Set body part animations
        UpdateAllBodyParts();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            UpdateClothe("Clothe", "Robes_Blue");
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            UpdateClothe("Clothe", "Robes_Violet");
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            UpdateClothe("Hat", "Stetson");
        }
    }

    public void UpdateClothe(string partType, string clotheName)
    {
        for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
        {
            string state = characterStates[stateIndex];
            for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
            {
                string direction = characterDirections[directionIndex];
                
                animationClip = Resources.Load<AnimationClip>(
                    "Animation/Player/" + partType + "/" + clotheName + "/" + partType + "_" + clotheName + "_" + state +
                    "_" + direction);

                Debug.Log(partType + "_" + "None" + "_" + state + "_" + direction);

                // Override default animation
                defaultAnimationClips[partType + "_" + "None" + "_" + state + "_" + direction] = animationClip;
            }
        }
        
        // Apply updated animations
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }

    public void UpdateAllBodyParts()
    {
        // Override default animation clips with character body parts
        for (int partIndex = 0; partIndex < bodyPartTypes.Length; partIndex++)
        {
            // Get current body part
            string partType = bodyPartTypes[partIndex];
            // Get current body part ID
            // string partID = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];
                    
                    animationClip = Resources.Load<AnimationClip>("Animation/Player/" + partType + "/" + "None" + "/Clothe_" + "None" + "_" + state + "_" + direction);
                    
                    Debug.Log(partType + "_" + "None" + "_" + state + "_" + direction);
                    
                    // Override default animation
                    defaultAnimationClips[partType + "_" + "None" + "_" + state + "_" + direction] = animationClip;
                }
            }
        }

        // Apply updated animations
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }

    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
}