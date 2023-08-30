using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndAnimateCat : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 3.0f;
    private Animator animator;

    private bool isWalking = false;
    private bool hasReachedTarget = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MoveAndPlayAnimation());
    }

    private IEnumerator MoveAndPlayAnimation()
    {
        Vector3 startPosition = transform.position;
        float journeyLength = Vector3.Distance(startPosition, targetPosition.position);
        float startTime = Time.time;

        while (transform.position != targetPosition.position)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, fractionOfJourney);

            if (!isWalking && animator != null)
            {
                animator.SetBool("IsWalking", true);
                isWalking = true;
            }

            yield return null;
        }

        hasReachedTarget = true;
    }

    private void Update()
    {
        if (hasReachedTarget && animator != null)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsSitting", true);
        }
    }
}
