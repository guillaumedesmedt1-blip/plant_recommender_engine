using System;
using PlantRecommender.Models;

namespace PlantRecommender.Services
{
    public class RecommenderService
    {
        private readonly List<Plant> plants;//hier dit veld even opslaan zodat andere methodes binnen deze klasse deze kunnen bewaren

        public RecommenderService()//dit is de constructor. Is een speciale methode die automatisch wordt uitgevoerd waneer je een nieuw object van de klasse maakt
        {
            plants = LoadPlants();
        }

        private List<Plant> LoadPlants()//private methode (enkel binnen deze klasse) die lijst van plantobjecten returnt (List<Plant>) met als naam LoadPlants()
        {
            var plants = new List<Plant>();

            var lines = File.ReadAllLines("Data/plant.csv");

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');

                var plant = new Plant
                {
                    Id = int.Parse(values[0]),
                    Name = values[1],
                    Category = values[2],
                    Light = values[3],
                    Watering = values[4],
                    Difficulty = values[5]
                };

                plants.Add(plant);
            }

            return plants;
        }
        public List<Plant> Recommend_by_difficulty(string difficulty)
        {
            List<Plant> recom_list = new List<Plant>();
            foreach (Plant plantje in plants)
            {
                if (plantje.Difficulty == difficulty)
                {
                    recom_list.Add(plantje);
                }
            }
            return recom_list;
        }
    }
}