## CardGame

You are given the following information:
# 1. Below is the list of cards in ASCENDING orders (each card has alphanumeric and symbol):
-----------------------------------------------------------------
| 2@ | 2# | 2^ | 2* | 3@ | 3# | 3^ | 3* | 4@ | 4# | 4^ | 4* |
| 5@ | 5# | 5^ | 5* | 6@ | 6# | 6^ | 6* | 7@ | 7# | 7^ | 7* |
| 8@ | 8# | 8^ | 8* | 9@ | 9# | 9^ | 9* | 10@ | 10# | 10^ | 10* |
| J@ | J# | J^ | J* | Q@ | Q# | Q^ | Q* | K@ | K# | K^ | K* |
| A@ | A# | A^ | A* |
-----------------------------------------------------------------
# 2. Shuffle (randomize) the cards and display the result.
# 3. Distribute ALL the cards in sequence to 4 players and display the result. Each player should have 13
cards.
# 4. Evaluate the winner based on the following conditions:
- Player with the highest number of cards with same alphanumeric part (i.e., K@, K#, K^, K*).
- If more than 1 player has the same number of winning cards, the alphanumeric part with higher
value won. If tie, the symbol part with high value won. Example:

----------------------------------
Sample 1: Player 1: K@, K#, K*
Player 2: A@, A#, A^ Winner
----------------------------------
Sample 2: Player 1: A@, A* Winner
Player 2: A#, A^
----------------------------------
5. Show the winning result and player.
Remark