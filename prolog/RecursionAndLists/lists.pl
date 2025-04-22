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
