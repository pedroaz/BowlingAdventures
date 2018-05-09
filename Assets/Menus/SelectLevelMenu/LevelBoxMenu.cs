using UnityEngine;
using UnityEngine.UI;

public class LevelBoxMenu : MonoBehaviour {

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Universe universe;


	void Start () {

        AddAllButtons();
    }
	
    public void AddAllButtons() {

        RemoveAllButtons();

        for (int i = 0; i < universe.selectedWorld.listOfLevels.Count; i++) {

            GameObject btn = Instantiate(buttonPrefab);
            btn.transform.parent = transform;
            btn.GetComponent<Button>().onClick.AddListener(universe.selectedWorld.listOfLevels[i].SelectThisLevel);
        }
    }

    void RemoveAllButtons() {


        for (int i = 0; i < transform.childCount; i++) {

            Destroy(transform.GetChild(i).gameObject);
        }

    }
    
}
