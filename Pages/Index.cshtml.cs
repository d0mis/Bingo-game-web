using Bingo_game_web.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Bingo_game_web.Pages
{
    public class IndexModel : PageModel
    {
        public int score = 0;
        [BindProperty]
        public int max { get; set; }
        [BindProperty]
        public int rows { get; set; }
        [BindProperty]
        public int columns { get; set; }
       public Card game { get; set; }

        public void OnGet()
    {
            
        }
     public IActionResult OnPost()
        {


            game = new Card(rows, columns, max);
            Rand numbers = new Rand(max); //crates a new list of numbers 0 to max
            numbers.Suffle(); //shuffles the list
            return Page();
           
        }
      
    }
}