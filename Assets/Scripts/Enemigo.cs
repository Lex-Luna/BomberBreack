using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemigo : MonoBehaviour
{
    public Animator animator;
    public float runSpead=0.7f;
    public int vida;
    public GameObject jugador;
    private float _x,_y;
    public Rigidbody rb;  
    public float tMuerdo=1;
    public Transform objetivoPlayer, objetivoCamino;//
    public float atrapeDistancia = 0.1f;
    public bool isGround;  
    public List<Transform> caminoList;
    
    


     void Awake() {
        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        // agente.destination = objetivoPlayer.position;
        objetivoCamino= caminoList[Random.Range(1,150)];
        agente.destination= objetivoCamino.position;
    }
    void Start()
    {
         
    }

    private float DistanciaJugador(){
        return Vector3.Distance(jugador.transform.position, transform.position);
    }

    void Update()
    {
        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        _x=Input.GetAxis("Horizontal");
        _y=Input.GetAxis("Vertical");
        transform.Translate(0,0,1*Time.deltaTime*runSpead);
        animator.SetFloat("Vely", 1);

        if(DistanciaJugador()<=1.5f){
            NavMeshAgent agentePlayer = GetComponent<NavMeshAgent>();
            agentePlayer.destination = objetivoPlayer.position;
        }
        if(agente.remainingDistance <=0.5f){
            //NavMeshAgent agente = GetComponent<NavMeshAgent>();
            // agente.destination = objetivoPlayer.position;
            objetivoCamino= caminoList[Random.Range(1,150)];
            agente.destination= objetivoCamino.position;
        }
        
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.name =="aj")
        {
            Debug.Log("T matare Perro");
            animator.Play("Morder");
            animator.SetBool("Mordido",false);
        }
        
             
    }

}
