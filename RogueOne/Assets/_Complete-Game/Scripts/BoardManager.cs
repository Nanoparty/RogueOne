using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

namespace Completed
	
{
	
	public class BoardManager : MonoBehaviour
	{
		// Using Serializable allows us to embed a class with sub properties in the inspector.
		[Serializable]
		public class Count
		{
			public int minimum; 			//Minimum value for our Count class.
			public int maximum; 			//Maximum value for our Count class.
			
			
			//Assignment constructor.
			public Count (int min, int max)
			{
				minimum = min;
				maximum = max;
			}
		}
		
		
		public int columns = 8; 										//Number of columns in our game board.
		public int rows = 8;											//Number of rows in our game board.
		public Count wallCount = new Count (5, 9);						//Lower and upper limit for our random number of walls per level.
		public Count foodCount = new Count (4, 8);						//Lower and upper limit for our random number of food items per level.
        public Count goldCount = new Count(2, 4);
		public GameObject exit;											//Prefab to spawn for exit.
		public GameObject[] floorTiles1;									//Array of floor prefabs.
        public GameObject[] floorTiles2;
        public GameObject[] floorTiles3;
        public GameObject[] floorTiles4;
        public GameObject[] floorTiles5;
        public GameObject[] floorTiles6;
        public GameObject[] floorTiles7;
        public GameObject[] floorTiles8;
        public GameObject[] floorTiles9;
        public GameObject[] floorTiles10;
        public GameObject[] wallTiles;									//Array of wall prefabs.
		public GameObject[] foodTiles;									//Array of food prefabs.
        public GameObject[] goldTiles;
		public GameObject[] enemyTiles;									//Array of enemy prefabs.
		public GameObject outerWallTile1;								//Array of outer tile prefabs.
        public GameObject outerWallTile2;
        public GameObject outerWallTile3;
        public GameObject outerWallTile4;
        public GameObject outerWallTile5;
        public GameObject outerWallTile6;
        public GameObject outerWallTile7;
        public GameObject outerWallTile8;

        public int style = 1;
        public int floorstyle = 1;

        private Transform boardHolder;									//A variable to store a reference to the transform of our Board object.
		private List <Vector3> gridPositions = new List <Vector3> ();	//A list of possible locations to place tiles.
		
		
		//Clears our list gridPositions and prepares it to generate a new board.
		void InitialiseList ()
		{
			//Clear our list gridPositions.
			gridPositions.Clear ();
			
			//Loop through x axis (columns).
			for(int x = 1; x < columns-1; x++)
			{
				//Within each column, loop through y axis (rows).
				for(int y = 1; y < rows-1; y++)
				{
					//At each index add a new Vector3 to our list with the x and y coordinates of that position.
					gridPositions.Add (new Vector3(x, y, 0f));
				}
			}
		}
		
		
		//Sets up the outer walls and floor (background) of the game board.
		void BoardSetup ()
		{
            style = Random.Range(1, 5);
            floorstyle = Random.Range(1, 11);

			//Instantiate Board and set boardHolder to its transform.
			boardHolder = new GameObject ("Board").transform;
			
			//Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
			for(int x = -1; x < columns + 1; x++)
			{
				//Loop along y axis, starting from -1 to place floor or outerwall tiles.
				for(int y = -1; y < rows + 1; y++)
				{
                    //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                    GameObject toInstantiate = floorTiles1[Random.Range(0, floorTiles1.Length)]; ;
                    switch (floorstyle) {
                        case 1:
                            toInstantiate = floorTiles1[Random.Range(0, floorTiles1.Length)];
                            break;
                        case 2:
                            toInstantiate = floorTiles2[Random.Range(0, floorTiles2.Length)];
                            break;
                        case 3:
                            toInstantiate = floorTiles3[Random.Range(0, floorTiles3.Length)];
                            break;
                        case 4:
                            toInstantiate = floorTiles4[Random.Range(0, floorTiles4.Length)];
                            break;
                        case 5:
                            toInstantiate = floorTiles5[Random.Range(0, floorTiles5.Length)];
                            break;
                        case 6:
                            toInstantiate = floorTiles6[Random.Range(0, floorTiles6.Length)];
                            break;
                        case 7:
                            toInstantiate = floorTiles7[Random.Range(0, floorTiles7.Length)];
                            break;
                        case 8:
                            toInstantiate = floorTiles8[Random.Range(0, floorTiles8.Length)];
                            break;
                        case 9:
                            toInstantiate = floorTiles9[Random.Range(0, floorTiles9.Length)];
                            break;
                        case 10:
                            toInstantiate = floorTiles10[Random.Range(0, floorTiles10.Length)];
                            break;
                    }


                    //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                    if (x == -1 || x == columns || y == -1)
                        toInstantiate = outerWallTile1;
                    if ((y == rows) && x != -1 && x != columns)
                        toInstantiate = outerWallTile2;

                    switch (style) {
                        case 1:
                            if (x == -1 || x == columns || y == -1)
                                toInstantiate = outerWallTile1;
                            if ((y == rows) && x != -1 && x != columns)
                                toInstantiate = outerWallTile2;
                            break;
                        case 2:
                            if (x == -1 || x == columns || y == -1)
                                toInstantiate = outerWallTile3;
                            if ((y == rows) && x != -1 && x != columns)
                                toInstantiate = outerWallTile4;
                            break;
                        case 3:
                            if (x == -1 || x == columns || y == -1)
                                toInstantiate = outerWallTile5;
                            if ((y == rows) && x != -1 && x != columns)
                                toInstantiate = outerWallTile6;
                            break;
                        case 4:
                            if (x == -1 || x == columns || y == -1)
                                toInstantiate = outerWallTile7;
                            if ((y == rows) && x != -1 && x != columns)
                                toInstantiate = outerWallTile8;
                            break;
                    }
					

                    //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                    GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					
					//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
					instance.transform.SetParent (boardHolder);
				}
			}
		}
		
		
		//RandomPosition returns a random position from our list gridPositions.
		Vector3 RandomPosition ()
		{
			//Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
			int randomIndex = Random.Range (0, gridPositions.Count);
			
			//Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
			Vector3 randomPosition = gridPositions[randomIndex];
			
			//Remove the entry at randomIndex from the list so that it can't be re-used.
			gridPositions.RemoveAt (randomIndex);
			
			//Return the randomly selected Vector3 position.
			return randomPosition;
		}
		
		
		//LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
		void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
		{
			//Choose a random number of objects to instantiate within the minimum and maximum limits
			int objectCount = Random.Range (minimum, maximum+1);
			
			//Instantiate objects until the randomly chosen limit objectCount is reached
			for(int i = 0; i < objectCount; i++)
			{
				//Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
				Vector3 randomPosition = RandomPosition();
				
				//Choose a random tile from tileArray and assign it to tileChoice
				GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
				
				//Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
				Instantiate(tileChoice, randomPosition, Quaternion.identity);
			}
		}
		
		
		//SetupScene initializes our level and calls the previous functions to lay out the game board
		public void SetupScene (int level)
		{
			//Creates the outer walls and floor.
			BoardSetup ();
			
			//Reset our list of gridpositions.
			InitialiseList ();
			
			//Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
			
			//Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);
            LayoutObjectAtRandom(goldTiles, goldCount.minimum, goldCount.maximum);

            //Determine number of enemies based on current level number, based on a logarithmic progression
            int enemyCount = (int)Mathf.Log(level, 2f);
			
			//Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);
			
			//Instantiate the exit tile in the upper right hand corner of our game board
			Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
		}

        void InstantiateSingle(GameObject prefab, float xCoord, float yCoord)
        {
            // The position to be instantiated at is based on the coordinates.
            Vector3 position = new Vector3(xCoord, yCoord, 0f);

            // Create an instance of the prefab from the random index of the array.
            GameObject tileInstance = Instantiate(prefab, position, Quaternion.identity) as GameObject;

            // Set the tile's parent to the board holder.
            tileInstance.transform.parent = boardHolder.transform;
        }
    }
}
