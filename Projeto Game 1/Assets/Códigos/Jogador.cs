using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    private Rigidbody rb;
    private AudioSource source;
    bool noChao; 

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out source);

    }
    

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(h,0,v);
        rb.AddForce(direcao * velocidade);

        if( Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb. AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            source.Play();
            noChao = false;
        }


        if(transform.position.y <= -10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision){ 
        if(!noChao && collision.gameObject.tag == "Chao"){
            noChao = true;
        }
      }
}
