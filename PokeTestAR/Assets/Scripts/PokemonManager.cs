using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PokemonManager : MonoBehaviour
{

    [Header("Pokemones")]
    [SerializeField] private GameObject charmander;
    [SerializeField] private GameObject bulbasaur;
    [SerializeField] private GameObject squirtle;
    [SerializeField] private GameObject pikachu;
    [SerializeField] private GameObject magikarp;

    [Header("Pokeball")]
    [SerializeField] private GameObject pokeball;
    [SerializeField] private GameObject throwButton;
    [SerializeField] private GameObject noMorePokeMsg;

    [HideInInspector] public int actualPokemon;

    private bool chAlreadyOut = false;
    private bool blAlreadyOut = false;
    private bool sqAlreadyOut = false;
    private bool pkAlreadyOut = false;
    private bool mkAlreadyOut = false;

    private int pokemonOut = 0;

    public static PokemonManager instanceP;

    private void Awake() {

        instanceP = this;

    }

    public int RandomPokemon(){

        return Random.Range(0,5);

    }

    public void ActivatePokemon(){
        
        actualPokemon = RandomPokemon();

        if(pokemonOut <= 4){
            switch(actualPokemon){
                case 0:
                    if(!charmander.activeSelf && chAlreadyOut == false){
                        charmander.SetActive(true);                       
                    }else{
                        ActivatePokemon();
                        return;
                    }
                break;
                case 1:
                    if(!bulbasaur.activeSelf && blAlreadyOut == false){
                        bulbasaur.SetActive(true);                        
                    }else{
                        ActivatePokemon();
                        return;
                    }
                break;
                case 2:
                    if(!squirtle.activeSelf && sqAlreadyOut == false){
                        squirtle.SetActive(true);                       
                    }else{
                        ActivatePokemon();
                        return;
                    }
                break;
                case 3:
                    if(!pikachu.activeSelf && pkAlreadyOut == false){
                        pikachu.SetActive(true);
                        
                    }else{
                        ActivatePokemon();
                        return;
                    }
                break;
                case 4:
                    if(!magikarp.activeSelf && mkAlreadyOut == false){
                        magikarp.SetActive(true);
                        
                        
                    }else{
                        ActivatePokemon();
                        return;
                    }
                break;
                default:
                    Debug.Log("error");
                break;
            }
        }else{
            noMorePokeMsg.SetActive(true);
        }
        pokeball.SetActive(true);
        throwButton.SetActive(true);

        PokedexManager.instancePM.PokedexInfoDeploy(this);

    }

    public void DesactivatePokemon(){

        switch(actualPokemon){
            case 0:
                charmander.SetActive(false);
            break;
            case 1:
                bulbasaur.SetActive(false);
            break;
            case 2:
                squirtle.SetActive(false);
            break;
            case 3:
                pikachu.SetActive(false);
            break;
            case 4:
                magikarp.SetActive(false);
            break;
            default:
                Debug.Log("error");
            break;
        }
        pokeball.SetActive(false);
        throwButton.SetActive(false);
        noMorePokeMsg.SetActive(false);
        
    }

    public void PokemonCapture(){
        switch(actualPokemon){
                case 0:
                    chAlreadyOut = true;      
                    pokemonOut += 1;
                break;
                case 1:
                    blAlreadyOut = true;
                        pokemonOut += 1;
                break;
                case 2:
                    sqAlreadyOut = true;
                        pokemonOut += 1;
                break;
                case 3:
                    pkAlreadyOut = true;
                        pokemonOut += 1;
                break;
                case 4:
                    mkAlreadyOut = true;
                    pokemonOut += 1;
                break;
                default:
                    Debug.Log("error");
                break;
            }
    }
}
