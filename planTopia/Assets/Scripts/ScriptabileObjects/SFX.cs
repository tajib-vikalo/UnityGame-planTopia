using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia
{
    [CreateAssetMenu(menuName = "planTopia/SFX", fileName = "SFX", order = 0)]
    public class SFX : ScriptableObject
    {
        public AudioClip SoundClip;
        public float Pitch;
        
    }
}
