using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 4f;

    private Animator anim;
    private float ultimoX, ultimoY;
    private float inputH, inputV;
    private float dt;
    private Vector3 incremento;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");
        incremento = CalculaPosicao(inputH, inputV, dt);

        transform.position += incremento;

        UpdateAnimation(incremento);
    }

    private Vector3 CalculaPosicao(float h, float v, float deltatime)
    {
        float dirH = h * velocidade * deltatime;
        float dirV = v * velocidade * deltatime;

        return new Vector3(dirH, dirV, 0);
    }

    private void UpdateAnimation(Vector3 dir)
    {
        if (dir.x == 0f && dir.y == 0f)
        {
            anim.SetFloat("UltimoX", ultimoX);
            anim.SetFloat("UltimoY", ultimoY);
            anim.SetBool("Movimento", false);
        }
        else
        {
            ultimoX = dir.x;
            ultimoY = dir.y;
            anim.SetBool("Movimento", true);
        }

        anim.SetFloat("DirecaoX", dir.x);
        anim.SetFloat("DirecaoY", dir.y);
    }
}
