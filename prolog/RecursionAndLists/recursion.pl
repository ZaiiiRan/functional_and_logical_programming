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

% fact_up(+N, ?X)
fact_up(0, 1).
fact_up(N, X) :-
    N > 0,
    N1 is N - 1,
    fact_up(N1, X1),
    X is N * X1.

% fact_down(+N, ?X)
fact_down(N, X) :-
    fact_tail(N, 1, X).

fact_tail(0, Acc, Acc).
fact_tail(N, Acc, X) :-
    N > 0,
    N1 is N - 1,
    NewAcc is Acc * N,
    fact_tail(N1, NewAcc, X).

% square_free(+N)
square_free(N) :-
    N > 0,
    Max is floor(sqrt(N)),
    check_square_factors(2, Max, N).

% check_square_factors(+K, +Max, +N)
check_square_factors(K, Max, _) :-
    K > Max, !.

check_square_factors(K, Max, N) :-
    Square is K * K,
    N mod Square =\= 0,
    K1 is K + 1,
    check_square_factors(K1, Max, N).
