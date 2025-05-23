infinite_capacity(100000000000000000).

% Пример 1 (10)
% edge(super_source, a, C) :- infinite_capacity(C).
% edge(super_source, b, C) :- infinite_capacity(C).
% edge(f, super_sink, C) :- infinite_capacity(C).
% edge(g, super_sink, C) :- infinite_capacity(C).
% edge(a, b, 7).
% edge(a, c, 4).
% edge(b, c, 4).
% edge(b, e, 2).
% edge(c, d, 4).
% edge(c, e, 8).
% edge(e, d, 4).
% edge(e, f, 5).
% edge(d, f, 12).

% Пример 2 (100)
% edge(super_source, a, C) :- infinite_capacity(C).
% edge(b, super_sink, C) :- infinite_capacity(C).
% edge(a, b, 100).
% edge(b, a, 1000).


% Пример 3 (3)
% edge(super_source, a, C) :- infinite_capacity(C).
% edge(d, super_sink, C) :- infinite_capacity(C).
% edge(a, b, 2).
% edge(a, c, 1).
% edge(b, c, 1).
% edge(b, d, 2).
% edge(c, b, 1).
% edge(c, d, 1).

% Пример 4 (141)
edge(super_source, 2, C) :- infinite_capacity(C).
edge(super_source, 4, C) :- infinite_capacity(C).

edge(5, super_sink, C) :- infinite_capacity(C).
edge(6, super_sink, C) :- infinite_capacity(C).
edge(8, super_sink, C) :- infinite_capacity(C).

edge(0, 1, 100).
edge(0, 5, 1).
edge(1, 5, 120).
edge(2, 0, 100).
edge(3, 0, 10).
edge(3, 1, 10).
edge(3, 7, 20).
edge(3, 9, 20).
edge(4, 3, 50).
edge(7, 6, 15).
edge(7, 8, 15).
edge(9, 7, 10).

source(super_source).
sink(super_sink).

% Начальное заполнение остаточной сети
init_residual :- 
    process_init_residual_edges.

process_init_residual_edges :-
    edge(X, Y, C),
    \+ residual(X, Y, _), % дважды одни и те же ребра не добавляем
    assertz(residual(X, Y, C)),
    assertz(residual(Y, X, 0)),
    fail.
process_init_residual_edges.


% BFS поиск увеличивающего пути
bfs(Path, MinCap) :-
    source(S),
    sink(T),
    bfs_visit([(S, [], inf)], [], T, RevPath, MinCap),
    reverse(RevPath, Path).

bfs_visit([(T, Path, Min)|_], _, T, [(T, Min)|Path], Min).
bfs_visit([(U, Path, Min)|Queue], Visited, T, ResultPath, MinCap) :-
    \+ member(U, Visited),
    findall(
        (V, [(U, Min)|Path], NewMin),
        (
            residual(U, V, C),
            C > 0,
            NewMin is min(Min, C),
            \+ member(V, Visited),
            \+ member((V, _, _), Queue)
        ),
        Neighbors
    ),
    append(Queue, Neighbors, NewQueue),
    bfs_visit(NewQueue, [U|Visited], T, ResultPath, MinCap).

% Обновить остаточную сеть
update_residual([], _).
update_residual([_], _).  % Последний элемент — это sink
update_residual([(U, _)|[(V, _)|Rest]], Min) :-
    retract(residual(U, V, C1)),
    C2 is C1 - Min,
    assertz(residual(U, V, C2)),
    retract(residual(V, U, R1)),
    R2 is R1 + Min,
    assertz(residual(V, U, R2)),
    update_residual([(V, _)|Rest], Min).

% Алгоритм Эдмондса-Карпа
max_flow(MaxFlow) :-
    retractall(residual(_,_,_)),
    init_residual,
    max_flow_loop(0, MaxFlow).

max_flow_loop(Acc, Max) :-
    bfs(Path, Min),
    !,
    update_residual(Path, Min),
    NewAcc is Acc + Min,
    max_flow_loop(NewAcc, Max).
max_flow_loop(Max, Max).  % больше нет путей
