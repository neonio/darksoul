using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public GameObject modelGameObject;

    public PlayerInput playerInput;

    [SerializeField]
    private Animator animator;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = modelGameObject.GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Forward", playerInput.currentMag);
        if (playerInput.currentMag > 0.01f)
        {
            modelGameObject.transform.forward = playerInput.currentVector;
        }
    }
}
