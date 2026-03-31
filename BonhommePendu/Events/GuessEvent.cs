using System.Security.Cryptography.X509Certificates;
using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            Events = new List<GameEvent>();

            var guessedLetterEvent = new GuessedLetterEvent(gameData, letter);
            var wrongGuessed = new WrongGuessEvent(gameData);
            
            Events.Add(guessedLetterEvent);

            bool letterFound = false;
            for(int i = 0;i < gameData.RevealedWord.Length; i++)
            {
                if(gameData.HasSameLetterAtIndex(letter, i))
                {
                    letterFound = true;
                    var revealLetter = new RevealLetterEvent(gameData, letter, i);
                    Events.Add(revealLetter);
                }
                
            }
            if (!letterFound)
            {
                Events.Add(wrongGuessed);
            }

            


        }
       
    }
}
