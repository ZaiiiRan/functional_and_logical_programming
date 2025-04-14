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
    write(Mother),
    nl, fail.

parent(X, Y) :-
    dite(Y, X).

brother(X, Y) :-
    man(X), 
    parent(P1, X), parent(P1, Y),
    parent(P2, X), parent(P2, Y),
    X \= Y.

brothers(X) :-
    setof(Y, brother(Y, X), Brothers),
    write(Brothers).

b_s(X, Y) :-
    parent(P1, X), parent(P1, Y),
    parent(P2, X), parent(P2, Y),
    X \= Y.

b_s(X) :-
    setof(Y, b_s(Y, X), Siblings),
    write(Siblings).

father(X, Y) :-
    man(X), parent(X, Y).

father(X) :-
    father(Y, X),
    write(Y),
    nl, fail.

sister(X, Y) :-
    woman(X),
    parent(P1, X), parent(P1, Y),
    parent(P2, X), parent(P2, Y),
    X \= Y.

sister(X) :-
    setof(Y, sister(Y, X), Sisters),
    write(Sisters).

grand_pa(X, Y) :-
    man(X),
    parent(X, Parent),
    parent(Parent, Y).

grand_pas(X) :-
    setof(G, grand_pa(G, X), Grandpas),
    write(Grandpas).

grand_pa_and_son(X, Y) :-
    grand_pa(X, Y).
grand_pa_and_son(X, Y) :-
    grand_pa(Y, X).

uncle(X, Y) :-
    man(X),
    parent(Parent, Y),
    b_s(X, Parent),
    X \= Parent.

uncles(X) :-
    setof(U, uncle(U, X), Uncles),
    write(Uncles).
