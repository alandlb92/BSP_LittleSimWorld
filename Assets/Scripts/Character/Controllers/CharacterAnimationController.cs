using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController
{
    public struct Configuration
    {
        public GameObject _bodyFront;
        public GameObject _bodySide;
        public GameObject _bodyBack;
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

        references._bodyBack.SetActive(references._rigidbody.velocity.y > 0 && references._rigidbody.velocity.x == 0);
        references._bodyFront.SetActive(references._rigidbody.velocity.y < 0 && references._rigidbody.velocity.x == 0);
        references._bodySide.SetActive(references._rigidbody.velocity.x != 0);
        references._bodySide.transform.rotation = Quaternion.Euler(new Vector3(0, references._rigidbody.velocity.x < 0 ? 180 : 0));
    }
}
