using System;
using System.Collections.Generic;
using UnityEngine;
using Hungath.UIManager;
using Random = System.Random;

namespace Hungath.Game
{
    public class TileManager : MonoBehaviour
    {
        public int numOfLandTiles, numOfBerryTiles, numOfGoatTiles, numOfPredatorTiles;
        private int[] _mapSize;
        private int _width, _height;
        private Random _random;

        private const float TileBuffer = 0.15f;

        [Header("Tile Percentages by Type")] 
        [SerializeField] private float landPercentage = 0.4f;
        [SerializeField] private float berryPercentage = 0.25f;
        [SerializeField] private float goatPercentage = 0.15f;
        [SerializeField] private float predatorPercentage = 0.2f;

        private void Awake()
        {
            _mapSize = GameManager.GetMapSize(Population.TotalPop);
            _width = _mapSize[0];
            _height = _mapSize[1];
            _random = new Random();
            DetermineNumberOfTileTypes();
            GenerateTiles();
        }

        private void GenerateTiles()
        {
            GameObject tileContainer = GameObject.Find("Tiles");
            float[] startPositions = GetStartPositions();
            float xPosition = startPositions[0];
            float yPosition = startPositions[1];

            int lands = numOfLandTiles;
            int berries = numOfBerryTiles;
            int goats = numOfGoatTiles;
            int predators = numOfPredatorTiles;

            List<int> tilePool = new List<int> {lands, berries, goats, predators};

            for (int w = 0; w < _width; w++)
            {
                for (int h = 0; h < _height; h++)
                {
                    GameObject tile = Resources.Load<GameObject>("Prefabs/Tile");
                    RandomAssign(tilePool, tile.GetComponent<TileBehavior>());

                    Instantiate(tile, new Vector3(xPosition, 0, yPosition), Quaternion.identity,
                        tileContainer.transform);
                    yPosition += 1.15f;
                }

                xPosition += 1.15f;
                yPosition = startPositions[1];
            }
        }

        private void RandomAssign(List<int> options, TileBehavior tile)
        {
            int selection = -1;
            bool looper = true;
            
            while (looper)
            {
                selection = _random.Next(options.Count);
                if (options[selection] > 0) looper = false;
            }

            switch (selection)
            {
                case 0:
                    tile.tileType = TileType.Land;
                    tile.tileImage = Resources.Load<Material>("Materials/TileFaceLand");
                    break;
                case 1:
                    tile.tileType = TileType.Berry;
                    tile.tileImage = Resources.Load<Material>("Materials/TileFaceBerry");
                    break;
                case 2:
                    tile.tileType = TileType.Goat;
                    tile.tileImage = Resources.Load<Material>("Materials/TileFaceGoat");
                    break;
                case 3:
                    tile.tileType = TileType.Predator;
                    tile.tileImage = Resources.Load<Material>("Materials/TileFacePredator");
                    break;
                default:
                    throw new NotImplementedException("No tile type here");
            }

            MeshRenderer meshRenderer = tile.face.GetComponent<MeshRenderer>();
            meshRenderer.material = tile.tileImage;
            options[selection] -= 1;
        }

        private float[] GetStartPositions()
        {
            float xPosition = (_width + (_width - 1) * TileBuffer) / -2;
            float yPosition = (_height + (_height - 1) * TileBuffer) / -2;

            return new [] {xPosition + 0.5f, yPosition + 0.5f};
        }

        private void DetermineNumberOfTileTypes()
        {
            int sumOfTiles = _height * _width;

            numOfLandTiles =        (int) Mathf.Round(sumOfTiles * landPercentage);
            numOfBerryTiles =       (int) Mathf.Round(sumOfTiles * berryPercentage);
            numOfGoatTiles =        (int) Mathf.Round(sumOfTiles * goatPercentage);
            numOfPredatorTiles =    (int) Mathf.Round(sumOfTiles * predatorPercentage);

            int sumOfCreatedTiles = numOfBerryTiles + numOfLandTiles + numOfGoatTiles + numOfPredatorTiles;

            if (sumOfCreatedTiles < sumOfTiles)
            {
                numOfPredatorTiles++;
            }
        }
    }
}
