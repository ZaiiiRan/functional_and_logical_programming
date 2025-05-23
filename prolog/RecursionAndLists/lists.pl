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

% read_list(-List)
read_list(List) :- 
    write('Введите число элементов списка: '), nl,
    read(N),
    write('Введите элементы списка: '), nl,
    r_list(List, N).

% count_after_last_max(+List, ?Count)
count_after_last_max(List, Count) :-
    max_in_list(List, Max),
    last_index_of(List, Max, LastMaxIdx),
    length(List, Len),
    Count is Len - LastMaxIdx - 1.

max_in_list([H|T], Max) :- max_in_list(T, H, Max).
max_in_list([], Max, Max).
max_in_list([H|T], CurMax, Max) :-
    max(H, CurMax, NewMax),
    max_in_list(T, NewMax, Max).

last_index_of(List, Elem, Index) :- 
    reverse(List, Rev),
    index_of_first(Rev, Elem, RevIdx),
    length(List, Len),
    Index is Len - RevIdx - 1.

index_of_first([Elem|_], Elem, 0) :- !.
index_of_first([_|T], Elem, Index) :- 
    index_of_first(T, Elem, Index1),
    Index is Index1 + 1.

print_after_last_max :-
    read_list(List),
    count_after_last_max(List, Count),
    write('Количество элементов после последнего максимального: '), write(Count), nl.

% move_before_min_to_end(+List, ?Result)
move_before_min_to_end(List, Result) :-
    min_in_list(List, Min),
    index_of_first(List, Min, MinIdx),
    split_at(List, MinIdx, Before, After),
    my_append(After, Before, Result).

min_in_list([H|T], Min) :- min_in_list(T, H, Min).
min_in_list([], Min, Min).
min_in_list([H|T], CurMin, Min) :-
    (H < CurMin -> NewMin = H ; NewMin = CurMin),
    min_in_list(T, NewMin, Min).

split_at(List, 0, [], List) :- !.
split_at([H|T], N, [H|B], A) :-
    N1 is N - 1,
    split_at(T, N1, B, A).

print_move_before_min :-
    read_list(List),
    move_before_min_to_end(List, Result),
    write('Результат: '), write(Result), nl.

% max_in_range(+List, +A, +B, ?Max)
max_in_range(List, A, B, Max) :-
    filter_range(List, A, B, Filtered),
    max_in_list(Filtered, Max).

filter_range([], _, _, []).
filter_range([H|T], A, B, [H|R]) :-
    H >= A, H =< B, !,
    filter_range(T, A, B, R).
filter_range([_|T], A, B, R) :-
    filter_range(T, A, B, R).

print_max_in_range :-
    read_list(List),
    write('Введите границы интервала A и B: '), nl,
    read(A), read(B),
    max_in_range(List, A, B, Max),
    write('Максимум в интервале: '), write(Max), nl.

% find_smaller_indices(+List, -Indices)
find_smaller_indices([_], []).
find_smaller_indices([Prev, Curr | T], Indices) :-
    find_smaller_indices([Prev, Curr | T], 2, [], Indices).

% find_smaller_indices(+List, +Index, +Acc, -Result)
find_smaller_indices([_, _], _, Acc, Acc) :- !.
find_smaller_indices([Prev, Curr | T], I, Acc, Result) :-
    (Curr < Prev -> append(Acc, [I], Acc1) ; Acc1 = Acc),
    T = [Next | Rest],
    I1 is I + 1,
    find_smaller_indices([Curr, Next | Rest], I1, Acc1, Result).

print_indices_and_count(Indices) :-
    write('Индексы: '), write(Indices), nl,
    length(Indices, Count),
    write('Количество: '), write(Count), nl.

print_smaller_indices :-
    read_list(L),
    find_smaller_indices(L, Indices),
    print_indices_and_count(Indices).

prime_divisors(N, D, Acc, Acc) :- D > N, !.
prime_divisors(N, D, Acc, List) :-
    (N mod D =:= 0, is_prime(D) -> 
        (in_list(Acc, D) -> Acc1 = Acc ; append(Acc, [D], Acc1))
    ; Acc1 = Acc),
    D1 is D + 1,
    prime_divisors(N, D1, Acc1, List).

% all_prime_divisors(+List, -Result)
all_prime_divisors([], []).
all_prime_divisors([H|T], Result) :-
    all_prime_divisors(T, RTail),
    prime_divisors(H, 2, [], D1),
    my_union(D1, RTail, Result).

% my_union(+List1, +List2, -Union) — объединение без повторений
my_union([], L, L).
my_union([H|T], L, R) :-
    in_list(L, H), !,
    my_union(T, L, R).
my_union([H|T], L, [H|R]) :-
    my_union(T, L, R).

print_positive_prime_divisors :-
    read_list(L),
    all_prime_divisors(L, Result),
    write('Простые делители: '), write(Result), nl.