% max(+X, +Y, -M)
max(X, Y, X) :- X > Y,!.
max(_, Y, Y).

% max(+X, +Y, +Z, -U)
max(X, Y, Z, X) :-
    X>Y,X>Z,!.
max(_, Y, Z, Y) :-
    Y>Z,!.
max(_, _, Z, Z).

% digit_sum_up(+N, ?S)
digit_sum_up(0, 0) :- !.
digit_sum_up(N, S) :- 
    Digit is N mod 10,
    NewN is N div 10,
    digit_sum_up(NewN, NewSum),
    S is NewSum + Digit.

% digit_sum_down(+N, ?S)
digit_sum_down(X, S) :-
    digit_sum_tail(X, 0, S).

digit_sum_tail(0, Acc, Acc) :- !.
digit_sum_tail(X, Acc, S) :-
    X1 is X div 10,
    Digit is X mod 10,
    Acc1 is Acc + Digit,
    digit_sum_tail(X1, Acc1, S).

my_append([], Y, Y).
my_append([X|Tail], Y, [X|Tail1]) :- my_append(Tail, Y, Tail1).

in_list([], _) :- false.
in_list([X|_], X).
in_list([_|T], X) :- in_list(T, X).

pr3_0:-read(N),r_list(A,N),w_list(A).
r_list(A,N):-r_list(A,N,0,[]).
r_list(A,N,N,A):-!.
r_list(A,N,K,B):-read(X),append(B,[X],B1),K1 is K+1,r_list(A,N,K1,B1).
w_list([]):-!.
w_list([H|T]):-write(H),nl,w_list(T).
