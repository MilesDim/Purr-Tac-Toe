using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CharacterState
{
    MovingToBox,
    InteractingWithBox,
    MovingAfterInteraction,
}
public class MoveAndAnimateCat : MonoBehaviour

{
    public Transform targetPosition;
    public float moveSpeed = 3.0f;
    private Animator animator;
     private CharacterState currentState = CharacterState.MovingToBox;
    private bool hasReachedTarget = false;
    private Vector3 targetPosition2;

    // private Ray lastRay;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Начать движение к начальной точке
        targetPosition2 = targetPosition.position;
        StartCoroutine(MoveAndPlayAnimation());
    }

    private void Update()
    { 

        // Debug.Log("!!Current animation = "+animator.GetCurrentAnimatorStateInfo(0).IsName("StandUp"));
        if (currentState == CharacterState.InteractingWithBox)
        {
            if (animator.GetBool("IsSitting"))  
            {
                // Проиграть анимацию "Up" при нажатии на коробку
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.CompareTag("Box"))
                        {
                            animator.SetTrigger("Up");
                            // targetPosition2 = hit.point;
                            targetPosition2 = hit.collider.bounds.center;
                            targetPosition2.y = transform.position.y;
                            // targetPosition2 = new Vector3(hit.point.x, 0, hit.point.z);
                        }
                    }
                }

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("StandUp")) // проблема тут
                {
                    animator.SetBool("IsSitting", false);
                    Debug.Log("MOVE up");
                    StartCoroutine(MoveAndPlayAnimation());
                }

            } 
        }
    }

    private IEnumerator MoveAndPlayAnimation()
    {
        Vector3 startPosition = transform.position; 
        float journeyLength = Vector3.Distance(startPosition, targetPosition2);
        float startTime = Time.time;  // Объявляем и инициализируем startTime здесь

        while (transform.position != targetPosition2)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = new Vector3(
                Mathf.Lerp(startPosition.x, targetPosition2.x, fractionOfJourney),
                targetPosition2.y,
                Mathf.Lerp(startPosition.z, targetPosition2.z, fractionOfJourney)
            );
 
            // if (animator != null)
            // {
            //     animator.SetBool("IsSitting", false);
            // }

            // Завершить анимацию, если осталось мало расстояния до цели
            if (Vector3.Distance(transform.position, targetPosition2) < 0.1f)
            {
                break;
            }

            yield return null;
        } 

        hasReachedTarget = true;
        currentState = CharacterState.InteractingWithBox; // Переключаем состояние на взаимодействие с коробкой 
        animator.SetBool("IsSitting", true);
    }
}


