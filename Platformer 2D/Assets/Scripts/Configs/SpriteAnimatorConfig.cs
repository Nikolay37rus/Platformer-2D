using System;
using System.Collections.Generic;
using UnityEngine;


namespace Configs
{
    public enum AnimStatePlayer
    {
        Idle = 0,
        Run = 1,
        Jump = 2

    }

    [CreateAssetMenu(fileName = "SpriteAnimatorConfig", menuName = "Configs/ Animator CFG", order = 0)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        public List<SpriteSequence> Sequences = new List<SpriteSequence>();

        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimStatePlayer Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }
    }
}
