using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokedexManager : MonoBehaviour
{

    [SerializeField] private GameObject pokemonPanel;

    [SerializeField] private Transform transformParent;

    private List<int> registeredPokemonIndex = new List<int>();

    private GameObject[] registeredPokemons = new GameObject[5];

    public static PokedexManager instancePM;

    [Serializable]
    public struct Pokemon{
        public string pokemonName;
        public string pokemonType;
        public string pokemonState;
        public Sprite pokemonSprite;
    }

    [SerializeField] Pokemon[] allPokemons;

    private void Awake() {

        instancePM =  this;

    }

    public void PokedexInfoDeploy(PokemonManager manager) {

        GameObject panel;

        if(!registeredPokemonIndex.Contains(manager.actualPokemon)){
            panel = Instantiate(pokemonPanel, transformParent);
            panel.transform.GetChild(0).GetComponent<Image>().sprite = allPokemons[manager.actualPokemon].pokemonSprite;
            panel.transform.GetChild(1).GetComponent<Text>().text = allPokemons[manager.actualPokemon].pokemonName;
            panel.transform.GetChild(2).GetComponent<Text>().text = allPokemons[manager.actualPokemon].pokemonType;
            panel.transform.GetChild(3).GetComponent<Text>().text = allPokemons[manager.actualPokemon].pokemonState;
            
            registeredPokemonIndex.Add(manager.actualPokemon);

            registeredPokemons[manager.actualPokemon] = panel;
        }
    }

    public void UpdatePokedex(){
        registeredPokemons[PokemonManager.instanceP.actualPokemon].transform.GetChild(3).GetComponent<Text>().text = "Capturado";
    }
}
