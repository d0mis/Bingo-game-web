using Bingo_game_web.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Bingo_game_web.Pages
{
    public class IndexModel : PageModel
    {
        public int score = 0;
        [BindProperty]
        public int max { get; set; } = 60;
        [BindProperty]
        public int rows { get; set; } = 3;
        [BindProperty]
        public int columns { get; set; } = 5;
        [BindProperty]
        public int draws { get; set; } = 30;
        public Card game { get; set; }

        public void OnGet()
    {
            game = new Card(rows, columns, max);
            Rand numbers = new Rand(max); //crates a new list of numbers 0 to max
            numbers.Suffle(); //shuffles the list
        }
     public IActionResult OnPostPlay()
        {
            game = new Card(rows, columns, max);
            Rand numbers = new Rand(max); //crates a new list of numbers 0 to max
            numbers.Suffle(); //shuffles the list
            for(int i = 0; i <draws; i++)
{
                int draw = numbers.draw(); //draws a number from the end of the list
                game.Mark(draw); //marks the number on the board
                
            }
            if (game.CheckBingo())
            {
                Console.WriteLine("BINGO");
                score += 1500;
            }
            else
            {
                for (int j = 0; j < rows; j++)
                    if (game.CheckRow(j))
                        score += 100;
            }
            return Page();
           
        }
     

    }
}