in_list([], _) :- false.
in_list([X|_], X).
in_list([_|T], X) :- in_list(T, X).

my_exclude(_, [], []).
my_exclude(X, [X|T], R) :- my_exclude(X, T, R).
my_exclude(X, [Y|T], [Y|R]) :- X \= Y, my_exclude(X, T, R).

print_people([]).
print_people([person(Name, Hair)|T]) :-
    write(Name), write(' is '), write(Hair), nl,
    print_people(T).

solve :-
    Colors = [blond, brunette, red],

    % Белокуров
    in_list(Colors, Hair1), Hair1 \= blond,
    my_exclude(Hair1, Colors, Colors1),

    % Рыжов
    in_list(Colors1, Hair2), Hair2 \= red,
    my_exclude(Hair2, Colors1, Colors2),

    % Чернов
    in_list(Colors2, Hair3), Hair3 \= brunette,

    People = [
        person(belokurov, Hair1),
        person(ryzhov, Hair2),
        person(chernov, Hair3)
    ],

    member(person(Speaker, brunette), People),
    Speaker \= belokurov,

    print_people(People).
