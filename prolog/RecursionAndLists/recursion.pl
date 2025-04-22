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

% product_digits_down(+N, ?Product)
product_digits_down(N, Product) :-
    N1 is abs(N),
    product_digits_tail(N1, 1, Product).

% product_digits_tail(+N, +Acc, ?Product)
product_digits_tail(0, Acc, Acc) :- !.
product_digits_tail(N, Acc, Product) :-
    D is N mod 10,
    N1 is N // 10,
    Acc1 is Acc * D,
    product_digits_tail(N1, Acc1, Product).

% product_digits_up(+N, ?Product)
product_digits_up(N, Product) :-
    N1 is abs(N),
    product_digits_up_(N1, Product).
product_digits_up_(0, 1) :- !.
product_digits_up_(N, Product) :-
    D is N mod 10,
    N1 is N // 10,
    product_digits_up_(N1, P1),
    Product is P1 * D.

% count_odd_gt3_down(+N, ?Count)
count_odd_gt3_down(N, Count) :-
    N1 is abs(N),
    count_odd_gt3_tail(N1, 0, Count).

count_odd_gt3_tail(0, Acc, Acc) :- !.
count_odd_gt3_tail(N, Acc, Count) :-
    D is N mod 10,
    N1 is N // 10,
    ( D mod 2 =:= 1, D > 3 -> Acc1 is Acc + 1 ; Acc1 is Acc ),
    count_odd_gt3_tail(N1, Acc1, Count).

% count_odd_gt3_up(+N, ?Count)
count_odd_gt3_up(N, Count) :-
    N1 is abs(N),
    count_odd_gt3_up_(N1, Count).

count_odd_gt3_up_(0, 0) :- !.
count_odd_gt3_up_(N, Count) :-
    D is N mod 10,
    N1 is N // 10,
    count_odd_gt3_up_(N1, C1),
    ( D mod 2 =:= 1, D > 3 -> Count is C1 + 1 ; Count is C1 ).

% gcd_down(+A, +B, ?GCD)
gcd_down(A, B, GCD) :-
    A1 is abs(A),
    B1 is abs(B),
    gcd_tail(A1, B1, GCD).

gcd_tail(A, 0, A) :- !.
gcd_tail(A, B, GCD) :-
    R is A mod B,
    gcd_tail(B, R, GCD).

% is_prime(+N)
is_prime(2) :- !.
is_prime(N) :- N > 2, not(has_divisor(N, 2)).

% has_divisor(+N, ?D)
has_divisor(N, D) :-
    D * D =< N,
    (N mod D =:= 0 ; D1 is D + 1, has_divisor(N, D1)).

% sum_prime_divisors(+N, ?Sum)
sum_prime_divisors(N, Sum) :-
    sum_prime_divisors(N, 2, 0, Sum).

sum_prime_divisors(N, D, Acc, Acc) :- D > N, !.
sum_prime_divisors(N, D, Acc, Sum) :-
    (N mod D =:= 0, is_prime(D) -> Acc1 is Acc + D ; Acc1 = Acc),
    D1 is D + 1,
    sum_prime_divisors(N, D1, Acc1, Sum).

task5_1 :-
    write('Введите число: '), read(N),
    sum_prime_divisors(N, Sum),
    write('Сумма простых делителей: '), write(Sum), nl.