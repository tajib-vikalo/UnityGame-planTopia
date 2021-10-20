using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia
{
    public interface IAudioPlayer
    {
        public void Play(SFX AudioClip);
        public void Stop();
        public void Pause();
    }
}
