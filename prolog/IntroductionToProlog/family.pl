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
    dite(Y, X),woman(X).

mother_of(X, Mother) :-
    dite(X, Mother),woman(Mother).

brother(X, Y) :-
    man(X),X\=Y,dite(X, Parent),dite(Y, Parent).

brothers(X, Brother) :-
    man(Brother),X\=Brother,dite(X,Parent),dite(Brother,Parent).