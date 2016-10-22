using UnityEngine;
using System.Collections;

public class DMPowerManager : MonoBehaviour {
    public string currentMonster;
    public string currentTrap;
    public GameObject dm;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SelectGasTrap()
    { currentTrap = "TrapGasSize";
        dm.GetComponent<DungeonMaster>().monsterSelected = false;
        dm.GetComponent<DungeonMaster>().monsterName = currentTrap;
    }
    public void SelectFloorTrap()
    { currentTrap = "TrapFloorSize";
        dm.GetComponent<DungeonMaster>().monsterSelected = false;
        dm.GetComponent<DungeonMaster>().monsterName = currentTrap;
    }
    public void SelectBruteMonster()
    { currentMonster = "MonsterBrute";
        dm.GetComponent<DungeonMaster>().monsterSelected = true;
        dm.GetComponent<DungeonMaster>().monsterName = currentMonster;
    }
    public void SelectGhostMonster()
    {currentMonster = "MonsterGhost";
        dm.GetComponent<DungeonMaster>().monsterSelected = true;
        dm.GetComponent<DungeonMaster>().monsterName = currentMonster;
    }
}
