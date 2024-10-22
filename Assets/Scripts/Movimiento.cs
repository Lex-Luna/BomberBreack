using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    public float runSpead=0.7f;
    public float rotacionSpead=250f;
    public Animator animator;
    private float _x,_y;
    public List<Transform> bombaList;
    public GameObject obArea;
    public NavMeshAgent navMeshAgent;

    private void Awake() {
        obArea.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("En contacto con "+other);
        if(other.name =="bomba"){
            UnityEngine.AI.NavMeshAgent agenteBomba = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agenteBomba.destination = other.transform.position;
        }

    }
    void DesactivarNav(){
        navMeshAgent.enabled=false;
    }
    void PonerBomba(){
            obArea.SetActive(true);
            navMeshAgent.enabled=true;
            animator.Play("Bomba");
            animator.SetBool("Other",false);
    }
    void Update()
    {
        obArea.SetActive(false);
        navMeshAgent.enabled=true;
        _x=Input.GetAxis("Horizontal");
        _y=Input.GetAxis("Vertical");
        transform.Rotate(0,_x*Time.deltaTime*rotacionSpead,0);
        transform.Translate(0,0,_y*Time.deltaTime*runSpead);
        animator.SetFloat("Velx", _x);
        animator.SetFloat("Vely", _y);

        if(Input.GetKey("space")){
            PonerBomba();
            Invoke("DesactivarNav",1.5f);
        }
        if( _x>0 ||  _x<0 ||  _y>0 || _y<0){
            animator.SetBool("Other",true);
        }
        
    } 
    
    
}
