# Rock, Paper, Scissors

Create a simple application to process a match of rock, paper, scissors.

### Game Rules
A match takes place between 2 players and is made up of 3 games, with the overall winner being the player who wins the most games.
Each game consists of both players selecting one of Rock, Paper or Scissors; the game winner is determined based on the following rules:
 - Rock beats scissors.
 - Scissors beats paper.
 - Paper beats rock.

## Requirements
Your application must support three types of player:
 - **Human player** - The user must be prompted for a selection of Rock, Paper or Scissors for each turn.
 - **Random computer player** - The random computer player should automatically select one of Rock, Paper or Scissors at random for each turn.
 - **Tactical Computer Player** - The tactical computer player should always select the choice that would have beaten its last choice, e.g. if it played Scissors in game 2, it should play Rock in game 3. It does not need to take the other player’s move into account.

You must include a user interface of some kind, but the choice of how this is implemented is up to you: console application, web site, WPF application, etc. – any are acceptable.

You must demonstrate that your solution implements all the above requirements correctly.

You must write high-quality code, using whatever principles you decide appropriate, and list any refactoring that you could make in the future.
You must use any high-level language – C#, Java, JavaScript, Python, PHP are all acceptable.

## Extensions
The following are some of the possible extensions that may be made to the application at a later date.  You do not need to implement these, but they should be considered in your design.
 - New player types: we may want to add new computer player implementations as tactics improve.
 - Longer matches: we may want to change the match format to “best of 5” at a later date.
 - New “moves”: we may expand the possible moves that each player can make (e.g. Rock, Paper, Scissors, Lizard, Spock).