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

% sum_list_down(+List, ?Summ)
sum_list_down(List, Summ) :-
    sum_list_tail(List, 0, Summ).

% sum_list_tail(+List, +Acc, ?Summ)
sum_list_tail([], Acc, Acc) :- !.
sum_list_tail([H|T], Acc, Summ) :-
    Acc1 is Acc + H,
    sum_list_tail(T, Acc1, Summ).

% sum_list_up(+List, ?Summ)
sum_list_up([], 0) :- !.
sum_list_up([H|T], Summ) :-
    sum_list_up(T, STail),
    Summ is H + STail.

pr_calc_sum_of_list :-
    read(N),
    r_list(A, N),
    sum_list_down(A, S),
    write(S), nl.

% digit_sum(+N, ?Sum)
digit_sum(N, Sum) :-
    N1 is abs(N),
    digit_sum(N1, 0, Sum). 
digit_sum(0, Acc, Acc) :- !.
digit_sum(N, Acc, Sum) :-
    D is N mod 10,
    N1 is N // 10,
    Acc1 is Acc + D,
    digit_sum(N1, Acc1, Sum).

% remove_by_digit_sum(+List, +TargetSum, ?Result)
remove_by_digit_sum(List, TargetSum, Result) :-
    remove_by_digit_sum(List, TargetSum, [], ResultRev),
    reverse(ResultRev, Result).

remove_by_digit_sum([], _, Acc, Acc) :- !.
remove_by_digit_sum([H|T], TargetSum, Acc, Result) :-
    digit_sum(H, DS),
    DS =:= TargetSum, !,
    remove_by_digit_sum(T, TargetSum, Acc, Result).
remove_by_digit_sum([H|T], TargetSum, Acc, Result) :-
    remove_by_digit_sum(T, TargetSum, [H|Acc], Result).
