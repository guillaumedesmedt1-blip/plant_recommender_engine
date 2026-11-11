using Microsoft.AspNetCore.Mvc;
using PlantRecommender.Services;

namespace PlantRecommender.Controllers
{
    [ApiController]//is een attribute, hiermee verklaar je dat deze klasse (hieronder) een API-controller is
    [Route("api/[controller]")]//bepaalt het basispad van de controller. Dit wordt dus /api/recommendations
    public class RecommendationsController : ControllerBase//deze klasse erft dus uit ControllerBase (geeft handige functies zoals Ok, NotFound, BadRequest,...)
    {
        private readonly RecommenderService recommenderService;//field (deze controller heeft een variabele genaamd recommenderService die later naar een RecommenderService-object zal verwijzen.)(zie mapje services)

        public RecommendationsController(RecommenderService recommenderService)//constructor
        {
            this.recommenderService = recommenderService;
        }

        [HttpGet("{difficulty}")]
        public IActionResult GetRecommendations(string difficulty)//de methode die uitgevoerd wordt als er zo'n request binnen komt
        {
            var recommendations = recommenderService.Recommend_by_difficulty(difficulty);

            if (recommendations.Count == 0)
            {
                return NotFound("No recommendations found.");//404'tje
            }
            return Ok(recommendations);//anders statuscode 200 + recoms
        }
    }
}