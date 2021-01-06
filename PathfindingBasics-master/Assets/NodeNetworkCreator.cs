using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeNetworkCreator : MonoBehaviour {

	public int boardWidth = 30;
	public int boardHeight = 40;

	public IDictionary<Vector3, bool> walkablePositions = new Dictionary<Vector3, bool>();
	public IDictionary<Vector3, GameObject> nodeReference = new Dictionary<Vector3, GameObject>();
	public Dictionary<Vector3, string> obstacles = new Dictionary<Vector3, string>();

	// Use this for initialization
	void Start () {
		InitializeNodeNetwork (6000, 1500, 2000);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeNodeNetwork(int numBarriers, int numSlow, int numVerySlow){
		
		var node = GameObject.Find ("Node");
		var obstacle = GameObject.Find ("Obstacle");
		var width = boardWidth;
		var height = boardHeight;

		obstacles = GenerateObstacles (numBarriers, numSlow, numVerySlow);

		Sprite slowTile = Resources.Load<Sprite> ("obstacle_slow 1");
		Sprite verySlowTile = Resources.Load<Sprite> ("obstacle_veryslow 1");

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				Vector3 newPosition = new Vector3 (i, 0, j);
				GameObject copy;
				string obstacleType = null;

				if (obstacles.TryGetValue (newPosition, out obstacleType)) {
					copy = Instantiate (obstacle);
					copy.transform.position = newPosition;
					switch (obstacleType) {
					case "barrier":
						walkablePositions.Add (new KeyValuePair<Vector3, bool> (newPosition, false));
						break;
					case "slow":
						walkablePositions.Add (new KeyValuePair<Vector3, bool> (newPosition, true));
						copy.GetComponent<SpriteRenderer> ().sprite = slowTile;
						break;
					case "verySlow":
						walkablePositions.Add (new KeyValuePair<Vector3, bool> (newPosition, true));
						copy.GetComponent<SpriteRenderer> ().sprite = verySlowTile;
						break;
					}
				}
				else {
					copy = Instantiate (node);
					copy.transform.position = newPosition;
					walkablePositions.Add (new KeyValuePair<Vector3, bool> (newPosition, true));
				}

				nodeReference.Add (newPosition, copy);
			}
		}
        
        GameObject goal = GameObject.Find("Goal");
        walkablePositions[goal.transform.localPosition] = true;
        nodeReference[goal.transform.localPosition] = goal;
    }

	Dictionary<Vector3, string> GenerateObstacles(int numBarriers, int numSlow, int numVerySlow){
        #region conveyor
        for (int i = 0; i < numBarriers; i++) {
			Vector3 nodePosition = new Vector3 ( 0, 0, Random.Range (1, boardHeight));
			if(!obstacles.ContainsKey(nodePosition)){
				obstacles.Add(nodePosition, "barrier");
			}
		}
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(91, 0, Random.Range(58, 66));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(91, 0, Random.Range(67, 88));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(91, 0, Random.Range(89, 96));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(91, 0, Random.Range(97, 133));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(91, 0, Random.Range(134, 145));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(89, 0, Random.Range(58, 64));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(89, 0, Random.Range(65, 90));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(89, 0, Random.Range(91, 123));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(89, 0, Random.Range(124, 145));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(87, 0, Random.Range(58, 145));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(93, 0, Random.Range(58, 80));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(93, 0, Random.Range(81, 90));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(93, 0, Random.Range(91, 145));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(95, 0, Random.Range(58, 62));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(95, 0, Random.Range(63, 76));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(95, 0, Random.Range(77, 90));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(95, 0, Random.Range(91, 136));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(95, 0, Random.Range(137, 145));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(97, 0, Random.Range(58, 75));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(97, 0, Random.Range(76, 100));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(97, 0, Random.Range(101, 145));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(97, 0, Random.Range(41, 57));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(99, 0, Random.Range(0, 146));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(97, 0, Random.Range(2, 40));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(Random.Range(2, boardWidth - 3), 0, 56);
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(2, 0, Random.Range(2, 39));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(Random.Range(2, boardWidth-3), 0, 39);
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(Random.Range(2, boardWidth - 3), 0, 41);
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(Random.Range(2, boardWidth-1), 0, 0);
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(Random.Range(0, boardWidth - 1), 0, 149);
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(Random.Range(2, boardWidth-3), 0, 2);
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(Random.Range(1, 87), 0, 58);
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        for (int i = 0; i < numBarriers; i++)
        {
            Vector3 nodePosition = new Vector3(2, 0, Random.Range(42, 57));
            if (!obstacles.ContainsKey(nodePosition))
            {
                obstacles.Add(nodePosition, "barrier");
            }
        }
        #endregion

        for (int i = 0; i < numSlow; i++) {
			Vector3 nodePosition = new Vector3 (Random.Range (0, boardWidth), 0, Random.Range (0, boardHeight));
			if (!obstacles.ContainsKey (nodePosition)) {
				obstacles.Add(nodePosition, "slow");
			}
		}

		for (int i = 0; i < numSlow; i++) {
			Vector3 nodePosition = new Vector3 (Random.Range (0, boardWidth), 0, Random.Range (0, boardHeight));
			if (!obstacles.ContainsKey (nodePosition)) {
				obstacles.Add(nodePosition, "verySlow");
			}
		}

		return obstacles;
	}
}
