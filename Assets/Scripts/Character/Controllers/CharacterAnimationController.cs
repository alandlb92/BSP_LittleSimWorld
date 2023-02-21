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
        UpdateDirection();
        references._animator.SetFloat("LinearVelocity", references._rigidbody.velocity.magnitude);
    }

    private void UpdateDirection()
    {
        if (references._rigidbody.velocity.magnitude == 0)
            return;

        references._bodyBack.enabled = references._rigidbody.velocity.y > 0 && references._rigidbody.velocity.x == 0;
        references._bodyFront.enabled = references._rigidbody.velocity.y < 0 && references._rigidbody.velocity.x == 0;
        references._bodyLeft.enabled = references._rigidbody.velocity.x != 0;
        references._bodyLeft.flipX = references._rigidbody.velocity.x < 0;
    }
}
