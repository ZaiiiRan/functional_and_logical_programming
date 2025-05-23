combination(0, _, []) :- !.
combination(K, [H|Alphabet], [H|Sub_set]) :-
    K > 0,
    K1 is K - 1,
    combination(K1, Alphabet, Sub_set).
combination(K, [_|Alphabet], Sub_set) :-
    K > 0,
    combination(K, Alphabet, Sub_set).

combination_rep(0, _, []) :- !.
combination_rep(K, [H|Alphabet], [H|Sub_set]) :-
    K > 0,
    K1 is K - 1,
    combination_rep(K1, [H|Alphabet], Sub_set).
combination_rep(K, [_|Alphabet], Sub_set) :-
    K > 0,
    combination_rep(K, Alphabet, Sub_set).

placement(0, _, []) :- !.
placement(K, Alphabet, [H|Placement]) :-
    K > 0,
    remove_one(H, Alphabet, NewAlphabet),
    K1 is K - 1,
    placement(K1, NewAlphabet, Placement).

remove_one(H, [H|Alphabet], Alphabet).
remove_one(X, [H|Alphabet], [H|Rest]) :-
    remove_one(X, Alphabet, Rest).

placement_rep(0, _, []) :- !.
placement_rep(K, Alphabet, [H|Placement]) :-
    K > 0,
    in_list(H, Alphabet),
    K1 is K - 1,
    placement_rep(K1, Alphabet, Placement).

in_list(H, [H|_]).
in_list(H, [_|List]) :-
    in_list(H, List).

permutation([], []) :- !.
permutation(Alphabet, [H|Permutation]) :-
    remove_one(H, Alphabet, NewAlphabet),
    permutation(NewAlphabet, Permutation).

my_length_up([], 0).
my_length_up([H|List], N) :-
    my_length_up(List, N1),
    N is N1 + 1.

my_length_tail([], Acc, Acc).
my_length_tail([H|List], Cur, Acc) :-
    NewAcc is Acc + 1,
    my_length_tail(List, Cur, NewAcc).

my_length(N, List) :-
    my_length_tail(List, N, 0).

% не работает, мы не знаем как сделать на прологе перестановки с повторениями
permutation_rep(Alphabet, X) :-
    my_length(N, Alphabet),
    placement_rep(N, Alphabet, X).
