using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController m_charCont;

    float m_horizontal;
    float m_vertical;
    float forwardDirection;
    float rightDirection;

    public float PlayerSpeed = 0.3f;
    [SerializeField]
    private float gravity = 9.81f;

    private Animator animatorCharacter;

	void Start () {
        m_charCont = GetComponent<CharacterController>();

        animatorCharacter = GetComponent<Animator>();
	}

	void Update () {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");
        forwardDirection = Vector3.Dot(transform.forward, new Vector3(m_horizontal, 0f, m_vertical));
        rightDirection = Vector3.Dot(transform.right, new Vector3(m_horizontal, 0f, m_vertical));
        animatorCharacter.SetFloat("Horizontal", rightDirection);
        animatorCharacter.SetFloat("Vertical", forwardDirection);

        Vector3 m_playerMovement = new Vector3(m_horizontal, 0f, m_vertical) * PlayerSpeed * Time.deltaTime;

        m_charCont.Move(m_playerMovement);

        
    }
}
