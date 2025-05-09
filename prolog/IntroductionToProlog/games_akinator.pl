multiplayer(the_witcher_3, 0).
multiplayer(minecraft, 1).
multiplayer(doom_1993, 1).
multiplayer(cs_2, 1).
multiplayer(stardew_valley, 1).
multiplayer(portal_2, 1).
multiplayer(fortnite, 1).
multiplayer(half_life_2, 0).
multiplayer(skyrim, 0).
multiplayer(hearts_of_iron_iv, 1).
multiplayer(tetris, 0).
multiplayer(world_of_warcraft, 1).
multiplayer(assassins_creed, 0).
multiplayer(rocket_league, 1).
multiplayer(the_sims_4, 0).
multiplayer(euro_truck_simulator, 0).
multiplayer(god_of_war, 0).
multiplayer(overwatch, 1).
multiplayer(dark_souls_iii, 1).
multiplayer(cyberpunk_2077, 0).

action(the_witcher_3, 1).
action(minecraft, 1).
action(doom_1993, 2).
action(cs_2, 2).
action(stardew_valley, 0).
action(portal_2, 0).
action(fortnite, 1).
action(half_life_2, 1).
action(skyrim, 1).
action(hearts_of_iron_iv, 0).
action(tetris, 0).
action(world_of_warcraft, 1).
action(assassins_creed, 1).
action(rocket_league, 1).
action(the_sims_4, 0).
action(euro_truck_simulator, 0).
action(god_of_war, 1).
action(overwatch, 2).
action(dark_souls_iii, 1).
action(cyberpunk_2077, 1).

series(the_witcher_3, 1).
series(minecraft, 0).
series(doom_1993, 1).
series(cs_2, 1).
series(stardew_valley, 0).
series(portal_2, 1).
series(fortnite, 0).
series(half_life_2, 1).
series(skyrim, 1).
series(hearts_of_iron_iv, 1).
series(tetris, 0).
series(world_of_warcraft, 1).
series(assassins_creed, 2).
series(rocket_league, 0).
series(the_sims_4, 2).
series(euro_truck_simulator, 1).
series(god_of_war, 1).
series(overwatch, 0).
series(dark_souls_iii, 1).
series(cyberpunk_2077, 0).

modern(the_witcher_3, 1).
modern(minecraft, 1).
modern(doom_1993, 0).
modern(cs_2, 1).
modern(stardew_valley, 1).
modern(portal_2, 1).
modern(fortnite, 1).
modern(half_life_2, 0).
modern(skyrim, 1).
modern(hearts_of_iron_iv, 1).
modern(tetris, 0).
modern(world_of_warcraft, 0).
modern(assassins_creed, 1).
modern(rocket_league, 1).
modern(the_sims_4, 1).
modern(euro_truck_simulator, 1).
modern(god_of_war, 1).
modern(overwatch, 1).
modern(dark_souls_iii, 1).
modern(cyberpunk_2077, 1).

openworld(the_witcher_3, 2).
openworld(minecraft, 2).
openworld(doom_1993, 0).
openworld(cs_2, 0).
openworld(stardew_valley, 1).
openworld(portal_2, 0).
openworld(fortnite, 2).
openworld(half_life_2, 0).
openworld(skyrim, 2).
openworld(hearts_of_iron_iv, 0).
openworld(tetris, 0).
openworld(world_of_warcraft, 2).
openworld(assassins_creed, 2).
openworld(rocket_league, 0).
openworld(the_sims_4, 0).
openworld(euro_truck_simulator, 2).
openworld(god_of_war, 1).
openworld(overwatch, 0).
openworld(dark_souls_iii, 0).
openworld(cyberpunk_2077, 2).

story(the_witcher_3, 2).
story(minecraft, 0).
story(doom_1993, 0).
story(cs_2, 0).
story(stardew_valley, 1).
story(portal_2, 1).
story(fortnite, 0).
story(half_life_2, 2).
story(skyrim, 1).
story(hearts_of_iron_iv, 0).
story(tetris, 0).
story(world_of_warcraft, 1).
story(assassins_creed, 2).
story(rocket_league, 0).
story(the_sims_4, 0).
story(euro_truck_simulator, 0).
story(god_of_war, 2).
story(overwatch, 0).
story(dark_souls_iii, 1).
story(cyberpunk_2077, 2).

question1(X1):- write("Is the game multiplayer?"),nl,
                write("1. Yes"),nl,
                write("0. No"),nl,
                read(X1).

question2(X2):- write("Is the game an action game?"),nl,
                write("2. Pure action (e.g., shooters)"),nl,
                write("1. Action with other elements (e.g., RPG, adventure)"),nl,
                write("0. Not action (e.g., strategy, simulator)"),nl,
                read(X2).

question3(X3):- write("Is the game part of a series?"),nl,
                write("2. Large series (many installments)"),nl,
                write("1. Regular series (a few installments)"),nl,
                write("0. Standalone game"),nl,
                read(X3).

question4(X4):- write("Was the game released after 2010?"),nl,
                write("1. Yes"),nl,
                write("0. No"),nl,
                read(X4).

question5(X5):- write("Does the game have an open world?"),nl,
                write("2. Fully open world"),nl,
                write("1. Partially open world"),nl,
                write("0. Linear or restricted world"),nl,
                read(X5).

question6(X6):- write("Does the game have a strong story?"),nl,
                write("2. Cinematic, deep story"),nl,
                write("1. Moderate or subtle story"),nl,
                write("0. Minimal or no story"),nl,
                read(X6).

start:-    question1(X1), question2(X2), question3(X3), question4(X4), question5(X5), question6(X6),
        multiplayer(X, X1), action(X, X2), series(X, X3), modern(X, X4), openworld(X, X5), story(X, X6),
        write("Your game is: "), write(X), nl.