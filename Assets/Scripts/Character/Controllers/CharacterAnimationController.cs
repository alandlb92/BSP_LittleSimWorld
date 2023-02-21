using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController
{
    public struct Configuration
    {
        public SpriteRenderer _bodyFront;
        public SpriteRenderer _bodyLeft;
        public SpriteRenderer _bodyBack;
        public Animator _animator;
        public Rigidbody2D _rigidbody;
    }

    private Configuration references;

    public CharacterAnimationController(Configuration config)
    {
        references = config;
    }

    public void Update()
    {
        references._animator.SetFloat("LinearVelocity", references._rigidbody.velocity.magnitude);
    }
}
