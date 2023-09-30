using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterModels; 
    public GameObject confirmButton; 
    private int selectedCharacterIndex = -1; 

    void Start()
    {
        foreach (GameObject model in characterModels)
        {
            model.SetActive(false); 
        }
       
        selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        characterModels[selectedCharacterIndex].SetActive(true);
    }

    public void SelectCharacter(int characterIndex)
    {
        if (selectedCharacterIndex != -1)
        {
            characterModels[selectedCharacterIndex].SetActive(false); 
        }


        characterModels[selectedCharacterIndex].SetActive(false); 
        selectedCharacterIndex = characterIndex;
        characterModels[selectedCharacterIndex].SetActive(true); 
        confirmButton.SetActive(true); 
        
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
        PlayerPrefs.Save();
    }
}
