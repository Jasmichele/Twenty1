using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Twenty1.Models;

namespace Twenty1.Controllers
{
    public class GameController : Controller
    {
        HttpClient client = new HttpClient();
        string url = "https://deckofcardsapi.com/api/deck";
        Deck currentDeck;

        public GameController()
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<ActionResult> Index()
        {

            HttpResponseMessage response = await client.GetAsync(url + "/new/shuffle/?deck_count=1");
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;

                currentDeck = JsonConvert.DeserializeObject<Deck>(responseData);
                return View(currentDeck);
            }
            return View("Error");
        }

        public async Task<ActionResult> NewGame()
        {
            CardViewModel game = new CardViewModel();

            game.deck_id = Request.QueryString["deck_id"];
            game.Dealer = new Person();
            game.Player = new Person();
            game.Dealer.Hand = new List<Card>();
            game.Player.Hand = new List<Card>();

            for (int i = 0; i < 2; i++)
            {
                game.Dealer.Hand.Add(await Hit(game.deck_id));
                game.Player.Hand.Add(await Hit(game.deck_id));
            }

            Session["gameSession"] = game;
            return View(game);
        }

        public async Task<Card> Hit(string deckId)
        {
            HttpResponseMessage response = await client.GetAsync(url + "/" + deckId + "/draw/?count=1");

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                var drawnCard = JsonConvert.DeserializeObject<DeckViewModel>(responseData);

                if (drawnCard.remaining == 0)
                    RedirectToAction("Index");

                return drawnCard.cards[0];
            }

            return null;
        }

        [HttpPost]
        public async Task<ActionResult> NewGame(string stay, string hit)
        {
            CardViewModel game = (CardViewModel)Session["gameSession"];
            if (hit != null)
            {
                game.Player.Hand.Add(await Hit(game.deck_id));
                return View(game);
            }
            if (stay != null)
            {
                while (game.Dealer.HandValue() <= 15)
                {
                    game.Dealer.Hand.Add(await Hit(game.deck_id));
                
                }
                var gameOver = true;

                while(!gameOver)
                {
                    while(game.Player.HandValue )
                }
                return View(game);
            }
            else
                return View(game);
        }


    }
}