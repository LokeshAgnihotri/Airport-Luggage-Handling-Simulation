using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

public class Agent : MonoBehaviour {

	IDictionary<Vector3, Vector3> nodeParents = new Dictionary<Vector3, Vector3>();
	public IDictionary<Vector3, bool> walkablePositions;
	public IDictionary<Vector3, string> obstacles;
	IDictionary<Vector3, Sprite> prevSprite = new Dictionary<Vector3, Sprite> ();

	NodeNetworkCreator nodeNetwork;
	IList<Vector3> path;

	bool solutionVisible;
	string prevAlgo;

    Camera camera;

    bool moveCube = false;
	int i;

	// Use this for initialization
	void Start ()
    {
        camera = FindObjectOfType<Camera>();
        nodeNetwork = GameObject.Find ("NodeNetwork").GetComponent<NodeNetworkCreator> ();
		obstacles = GameObject.Find ("NodeNetwork").GetComponent<NodeNetworkCreator> ().obstacles;
		walkablePositions = nodeNetwork.walkablePositions;
	}
	
	// Update is called once per frame
	void Update () {

        camera.transform.position = new Vector3(this.transform.position.x,40, this.transform.position.z);

		//Hacky way to move the cube along the path.
		if (moveCube) {
            float speed = 35 / Weight(path[i]);
			float step = Time.deltaTime * speed;
			transform.position = Vector3.MoveTowards (transform.position, path[i], step);
			if (transform.position.Equals (path [i]) && i >= 0)
				i--;
			if (i < 0)
				moveCube = false;
		}
	}

    int EuclideanEstimate(Vector3 node, Vector3 goal)
    {
        return (int) Mathf.Sqrt(Mathf.Pow(node.x - goal.x, 2) +
            Mathf.Pow(node.y - goal.y, 2) +
            Mathf.Pow(node.z - goal.z, 2));
    }

    int ManhattanEstimate(Vector3 node, Vector3 goal)
    {
        return (int) (Mathf.Abs(node.x - goal.x) +
            Mathf.Abs(node.y - goal.y) +
            Mathf.Abs(node.z - goal.z));
    }

    int HeuristicCostEstimate(Vector3 node, Vector3 goal, string heuristic)
    {
        switch (heuristic)
        {
            case "euclidean":
                return EuclideanEstimate(node, goal);
            case "manhattan":
                return ManhattanEstimate(node, goal);
        }

        return -1;
    }

    

	//Dijkstra's algorithm.
	//Populates IList<Vector3> path with a valid solution to the goalPosition.
	//Returns the goalPosition if a solution is found.
	//Returns the startPosition if no solution is found.
	Vector3 FindShortestPathDijkstra(Vector3 startPosition, Vector3 goalPosition){

        uint nodeVisitCount = 0;
        float timeNow = Time.realtimeSinceStartup;

        //A priority queue containing the shortest distance so far from the start to a given node
        IPriorityQueue<Vector3, int> priority = new SimplePriorityQueue<Vector3, int>();

        //A list of all nodes that are walkable, initialized to have infinity distance from start
        IDictionary<Vector3, int> distances = walkablePositions
            .Where(x => x.Value == true)
            .ToDictionary(x => x.Key, x => int.MaxValue);

        //Our distance from the start to itself is 0
        distances[startPosition] = 0;
        priority.Enqueue(startPosition, 0);

        while (priority.Count > 0) {

            Vector3 curr = priority.Dequeue();
            nodeVisitCount++;

            if (curr == goalPosition) {
                // If the goal position is the lowest position in the priority queue then there are
                //    no other nodes that could possibly have a shorter path.
                print("Dijkstra: " + distances[goalPosition]);
                print("Dijkstra time: " + (Time.realtimeSinceStartup - timeNow).ToString());
                print(string.Format("Dijkstra visits: {0} ({1:F2}%)", nodeVisitCount, (nodeVisitCount / (double)walkablePositions.Count) * 100));

                return goalPosition;
            }

			IList<Vector3> nodes = GetWalkableNodes (curr);

			//Look at each neighbor to the node
			foreach (Vector3 node in nodes) {

                int dist = distances[curr] + Weight(node);

                //If the distance to the parent, PLUS the distance added by the neighbor,
                //is less than the current distance to the neighbor,
                //update the neighbor's paent to curr, update its current best distance
                if (dist < distances [node]) {
					distances [node] = dist;
					nodeParents [node] = curr;

                    if (!priority.Contains(node))
                    {
                        priority.Enqueue(node, dist);
                    }
                }
			}
		}

        return startPosition;
	}

	int Weight(Vector3 node) {
		if (obstacles.Keys.Contains(node)) {
			if (obstacles [node] == "slow") {
				return 3;
			} else if (obstacles [node] == "verySlow") {
				return 5;
			} else {
				return 1;
			}
		} else {
			return 1;
		}
	}

	
	bool CanMove(Vector3 nextPosition) {
		return (walkablePositions.ContainsKey (nextPosition) ? walkablePositions [nextPosition] : false);
	}

	public void DisplayShortestPath(string algorithm) {

		if (solutionVisible && algorithm == prevAlgo) {
			foreach (Vector3 node in path) {
				nodeNetwork.nodeReference [node].GetComponent<SpriteRenderer> ().sprite = prevSprite[node];
			}

			solutionVisible = false;
			return;
		}
			
		nodeParents = new Dictionary<Vector3, Vector3>();
		path = FindShortestPath (algorithm);

		if (path == null)
			return;

		Sprite exploredTile = Resources.Load <Sprite>("path 1");
		Sprite victoryTile = Resources.Load<Sprite> ("victory 1");
		Sprite dijkstraTile = Resources.Load<Sprite> ("dijkstra");

		foreach (Vector3 node in path) {
			
			prevSprite[node] = nodeNetwork.nodeReference [node].GetComponent<SpriteRenderer> ().sprite;

        
                nodeNetwork.nodeReference[node].GetComponent<SpriteRenderer>().sprite = dijkstraTile;
           
		}

		nodeNetwork.nodeReference [path [0]].GetComponent<SpriteRenderer> ().sprite = victoryTile;

		i = path.Count - 1;

		solutionVisible = true;
		prevAlgo = algorithm;
	}

	public void MoveCube(){
		moveCube = true;
	}

	IList<Vector3> FindShortestPath(string algorithm){

		IList<Vector3> path = new List<Vector3> ();
		Vector3 goal;
      
            goal = FindShortestPathDijkstra(this.transform.localPosition, GameObject.Find("Goal").transform.localPosition);
       

		if (goal == this.transform.localPosition || !nodeParents.ContainsKey(nodeParents[goal])) {
			//No solution was found.
			return null;
		}

		Vector3 curr = goal;
		while (curr != this.transform.localPosition) {
			path.Add (curr);
			curr = nodeParents [curr];
		}

		return path;
	}

	IList<Vector3> GetWalkableNodes(Vector3 curr) {

		IList<Vector3> walkableNodes = new List<Vector3> ();

		IList<Vector3> possibleNodes = new List<Vector3> () {
			new Vector3 (curr.x + 1, curr.y, curr.z),
			new Vector3 (curr.x - 1, curr.y, curr.z),
			new Vector3 (curr.x, curr.y, curr.z + 1),
			new Vector3 (curr.x, curr.y, curr.z - 1),
            new Vector3 (curr.x + 1, curr.y, curr.z + 1),
            new Vector3 (curr.x + 1, curr.y, curr.z - 1),
            new Vector3 (curr.x - 1, curr.y, curr.z + 1),
            new Vector3 (curr.x - 1, curr.y, curr.z - 1)
        };

		foreach (Vector3 node in possibleNodes) {
			if (CanMove (node)) {
				walkableNodes.Add (node);
			} 
		}

		return walkableNodes;
	}
}
