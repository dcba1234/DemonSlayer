using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Sound
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;
        [HideInInspector]
        public AudioSource source;
    }
}
