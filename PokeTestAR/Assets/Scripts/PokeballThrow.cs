using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PokeballThrow : MonoBehaviour
{
    private Rigidbody rb;


    [SerializeField] private float throwForce = 5;

    [SerializeField] private GameObject captureTextT;
    [SerializeField] private GameObject captureTextF;
    [SerializeField] private Transform pokeballSpawn;

    [HideInInspector] public int randCapture;

    [SerializeField] UnityEvent onCapture;

    public static PokeballThrow instancePT;

    private void Awake() {

        instancePT = this;

    }

    private void Start() {

        rb = GetComponent<Rigidbody>();

    }

    public void ThrowPokeball(){

        rb.AddForce(transform.forward * throwForce);
        rb.AddForce(transform.up * 120f);
        rb.useGravity = true;

        Invoke("ResetPokeball", 4);

    }

    public void OnTriggerEnter(Collider other) {

        randCapture = Random.Range(0,2);

        if(randCapture == 1){
            captureTextT.SetActive(true);
            onCapture?.Invoke();
        }else{
            captureTextF.SetActive(true);
            PokemonManager.instanceP.DesactivatePokemon();
            PokemonManager.instanceP.ActivatePokemon();
        }

    }
    
    private IEnumerator Delete(){
        yield return new WaitForSeconds(1.5f);
        captureTextF.SetActive(false);
        captureTextT.SetActive(false);
    }

    public void DeleteMessage(){

        StartCoroutine(Delete());

    }

    public void ResetPokeball(){
        transform.position = pokeballSpawn.position;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        CancelInvoke("ResetPokeball");
    }

}
