man(anatoliy).
man(dimitriy).
man(vlad).
man(kirill).
man(mefodiy).
woman(vladina).
woman(galya).
woman(sveta).
woman(zoya).
woman(katrin).
dite(dimitriy, anatoliy).
dite(dimitriy, galya).
dite(vladina, anatoliy).
dite(vladina, galya).
dite(kirill, dimitriy).
dite(mefodiy, dimitriy).
dite(kirill, sveta).
dite(mefodiy, sveta).
dite(zoya, vlad).
dite(zoya, vladina).
dite(katrin, vlad).
dite(katrin, vladina).

men(X) :- 
    man(X).

women(X) :-
    woman(X).

children(X, Y, Z) :-
    dite(Y, X),
    dite(Z, Y).

mother(X, Y) :-
    dite(Y, X), woman(X).

mother_of(X) :-
    dite(X, Mother), 
    woman(Mother),
    write(Mother).

parent(X, Y) :-
    dite(Y, X).

brother(X, Y) :-
    man(X), 
    parent(P1, X), parent(P1, Y),
    parent(P2, X), parent(P2, Y),
    X \= Y.

brothers(X) :-
    brother(Y, X), 
    write(Y), 
    nl.